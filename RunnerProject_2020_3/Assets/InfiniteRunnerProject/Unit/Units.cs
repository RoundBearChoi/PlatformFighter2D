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
        private List<BaseUnitCreator> _listUnitCreators = new List<BaseUnitCreator>();
        private BaseStage _stage = null;

        public Units(BaseStage ownerStage)
        {
            instance = this;
            _stage = ownerStage;
            unitsMessageHandler = new UnitsMessageHandler(_listUnits);
        }

        public void AddCreator(BaseUnitCreator creator)
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

        public void ProcessCreators()
        {
            foreach (BaseUnitCreator creator in _listUnitCreators)
            {
                creator.AddUnits(_listUnits);
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
                    BaseMessage zeroHealthMessage = new ZeroHealth_Message(_listUnits[i]);
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
                if (_listUnits[i].transform.position.y < _stage.transform.position.y + GameInitializer.current.gameDataSO.DefaultFallDeathY)
                {
                    if (_listUnits[i].unitData.rigidBody2D != null)
                    {
                        if (_listUnits[i].unitType == UnitType.RUNNER)
                        {
                            if (_listUnits[i].unitData.hp > 0)
                            {
                                BaseMessage shakeCamOnPosition = new ShakeCameraOnPositionMessage(20);
                                shakeCamOnPosition.Register();
                            }
                        }

                        _listUnits[i].unitData.rigidBody2D.gravityScale = 0f;
                        _listUnits[i].unitData.rigidBody2D.velocity = Vector2.zero;
                        _listUnits[i].unitData.hp = 0;
                    }
                }
            }

            //cumulative gravity force on fall
            for (int i = 0; i < _listUnits.Count; i++)
            {
                if (_listUnits[i].unitData.rigidBody2D != null)
                {
                    if (_listUnits[i].unitData.collisionStays.GetCount() == 0)
                    {
                        if (_listUnits[i].unitData.rigidBody2D.bodyType != RigidbodyType2D.Static)
                        {
                            if (_listUnits[i].unitData.rigidBody2D.gravityScale > 0f)
                            {
                                if (_listUnits[i].unitData.collisionStays.GetCount() == 0)
                                {
                                    if (_listUnits[i].unitData.rigidBody2D.velocity.y < 0f)
                                    {
                                        Debugger.Log("adding downforce to unit: " + _listUnits[i].gameObject.name);

                                        float y = _listUnits[i].unitData.rigidBody2D.velocity.y * GameInitializer.current.gameDataSO.CumulativeGravityForcePercentage;
                                        float x = _listUnits[i].unitData.rigidBody2D.velocity.x;
                                        _listUnits[i].unitData.rigidBody2D.velocity = new Vector2(x, y);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < _listUnits.Count; i++)
            {
                _listUnits[i].unitData.comboHitCount.OnFixedUpdate();
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
                    //Debugger.Log("destroying: " + _listUnits[i].gameObject.name);
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