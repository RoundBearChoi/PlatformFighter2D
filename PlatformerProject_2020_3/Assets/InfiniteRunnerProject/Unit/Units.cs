using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Units
    {
        public static Units instance = null;
        public BaseMessageHandler unitsMessageHandler = null;

        private List<Unit> _listUnits = new List<Unit>();
        private List<UnitCreator> _listUnitCreators = new List<UnitCreator>();
        private BaseStage _stage = null;

        public Units(BaseStage ownerStage)
        {
            instance = this;
            _stage = ownerStage;
            unitsMessageHandler = new UnitsMessageHandler(_listUnits);
        }

        public void AddCreator(UnitCreator creator)
        {
            _listUnitCreators.Add(creator);
        }

        public void AddUnit(Unit unit)
        {
            _listUnits.Add(unit);
        }

        public Unit GetUnit<T>()
        {
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                if (_listUnits[i] is T)
                {
                    return _listUnits[i];
                }
            }

            return null;
        }

        public List<Unit> GetUnits<T>()
        {
            List<Unit> list = new List<Unit>();

            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                if (_listUnits[i] is T)
                {
                    list.Add(_listUnits[i]);
                }
            }

            return list;
        }

        public Unit GetLatestUnitByState<T>()
        {
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                if (_listUnits[i].iStateController != null)
                {
                    if (_listUnits[i].iStateController.GetCurrentState() != null)
                    {
                        if (_listUnits[i].iStateController.GetCurrentState() is T)
                        {
                            return _listUnits[i];
                        }
                    }
                }
            }

            return null;
        }

        public void ProcessCreators(BaseStage stage)
        {
            foreach (UnitCreator creator in _listUnitCreators)
            {
                Unit unit = creator.DefineUnit(stage);
                _listUnits.Add(unit);
            }

            _listUnitCreators.Clear();
        }

        public void OnUpdate()
        {
            for (int i = 0; i < _listUnits.Count; i++)
            {
                _listUnits[i].OnUpdate();

                if (_listUnits[i].hpBar != null)
                {
                    _listUnits[i].hpBar.Update();
                }
            }
        }

        public void OnFixedUpdate()
        {
            for (int i = 0; i < _listUnits.Count; i++)
            {
                if (_listUnits[i].unitData.hp <= 0)
                {
                    BaseMessage zeroHealthMessage = new Message_ZeroHealth(_listUnits[i]);
                    zeroHealthMessage.Register();
                }
            }

            //directions
            for (int i = 0; i < _listUnits.Count; i++)
            {
                if (_listUnits[i].unitData.facingRight)
                {
                    if (_listUnits[i].transform.rotation.y != 0f)
                    {
                        _listUnits[i].transform.rotation = Quaternion.Euler(_listUnits[i].transform.rotation.x, 0f, _listUnits[i].transform.rotation.z);
                    }
                }
                else
                {
                    if (_listUnits[i].transform.rotation.y != 180f)
                    {
                        _listUnits[i].transform.rotation = Quaternion.Euler(_listUnits[i].transform.rotation.x, 180f, _listUnits[i].transform.rotation.z);
                    }
                }
            }

            //death by fall
            for (int i = 0; i < _listUnits.Count; i++)
            {
                if (_listUnits[i].transform.position.y < _stage.transform.position.y + BaseInitializer.current.runnerDataSO.DefaultFallDeathY)
                {
                    if (_listUnits[i].unitData.rigidBody2D != null)
                    {
                        if (_listUnits[i].unitType == UnitType.RUNNER)
                        {
                            if (_listUnits[i].unitData.hp > 0)
                            {
                                BaseMessage shakeCamOnPosition = new Message_ShakeCameraOnPosition(_stage.CAMERA_SCRIPT, 20, 2f);
                                shakeCamOnPosition.Register();
                            }
                        }
                        else if (_listUnits[i].unitType == UnitType.LITTLE_RED_LIGHT ||
                            _listUnits[i].unitType == UnitType.LITTLE_RED_DARK)
                        {
                            if ((_listUnits[i].iStateController.GetCurrentState() is LittleRed_Death) == false)
                            {
                                BaseMessage shakeCamOnPosition = new Message_ShakeCameraOnPosition(_stage.CAMERA_SCRIPT, 25, 2f);
                                shakeCamOnPosition.Register();

                                BaseMessage showFallDust = new Message_ShowFallDust(_stage.CAMERA_SCRIPT, _listUnits[i].transform.position);
                                showFallDust.Register();

                                _listUnits[i].unitData.listNextStates.Add(new LittleRed_Death(_listUnits[i]));
                            }
                        }

                        _listUnits[i].unitData.rigidBody2D.gravityScale = 0f;
                        _listUnits[i].unitData.rigidBody2D.velocity = Vector2.zero;
                        _listUnits[i].unitData.hp = 0;

                        _listUnits[i].unitData.airControl.SetMomentum(0f);
                    }
                }
            }

            //cumulative gravity force on fall
            for (int i = 0; i < _listUnits.Count; i++)
            {
                if (!_listUnits[i].isDummy &&
                    _listUnits[i].unitData.rigidBody2D != null)
                {
                    if (_listUnits[i].unitData.rigidBody2D.bodyType != RigidbodyType2D.Static &&
                        _listUnits[i].unitData.rigidBody2D.gravityScale > 0f &&
                        _listUnits[i].unitData.rigidBody2D.velocity.y < -0.0001f)
                    {
                        //Debugger.Log("adding downforce to unit: " + _listUnits[i].gameObject.name);

                        float y = _listUnits[i].unitData.rigidBody2D.velocity.y * BaseInitializer.current.GetStage().GetCumulativeGravityForcePercentage();
                        float x = _listUnits[i].unitData.rigidBody2D.velocity.x;
                        _listUnits[i].unitData.rigidBody2D.velocity = new Vector2(x, y);
                    }
                }
            }

            //main fixedupdate
            for (int i = 0; i < _listUnits.Count; i++)
            {
                _listUnits[i].OnFixedUpdate();
            }

            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                if (_listUnits[i].destroy == true)
                {
                    //Debugger.Log("destroying unit: " + _listUnits[i].gameObject.name);
                    GameObject.Destroy(_listUnits[i].gameObject);
                    _listUnits.RemoveAt(i);
                }
            }
        }

        public void OnLateUpdate()
        {
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                _listUnits[i].OnLateUpdate();
            }

            unitsMessageHandler.HandleMessages();
            unitsMessageHandler.ClearMessages();

            foreach (Unit unit in _listUnits)
            {
                if (unit.messageHandler != null)
                {
                    unit.messageHandler.HandleMessages();
                    unit.messageHandler.ClearMessages();
                }
            }
        }
    }
}