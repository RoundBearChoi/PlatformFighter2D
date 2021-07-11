using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Units
    {
        public static Units instance = null;

        private List<Unit> _listUnits = new List<Unit>();
        private List<BaseUnitCreator> _listUnitCreators = new List<BaseUnitCreator>();

        public List<BaseMessage> listMessages = new List<BaseMessage>();

        public Units()
        {
            instance = this;
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

        public void ProcessCreators()
        {
            foreach (BaseUnitCreator creator in _listUnitCreators)
            {
                creator.AddUnits(_listUnits);
            }

            _listUnitCreators.Clear();
        }

        public void OnFixedUpdate()
        {
            //main update
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                if (_listUnits[i].unitData.spriteAnimations != null)
                {
                    _listUnits[i].unitData.spriteAnimations.MatchAnimationToState();
                }
                
                if (_listUnits[i].unitData.faceRight)
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

                if (_listUnits[i].unitData.boxCollider2D != null)
                {
                    _listUnits[i].SetCurrentVelocity(_listUnits[i].unitData.boxCollider2D.attachedRigidbody.velocity);
                }

                _listUnits[i].OnFixedUpdate();

                if (_listUnits[i].ProcessDamage())
                {
                    _listUnits[i].RunHitReactionAnimation();
                }
            }

            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                if (_listUnits[i].unitData.health <= 0)
                {
                    _listUnits[i].RunDeathAnimation();
                }

                if (_listUnits[i].destroy)
                {
                    GameObject.Destroy(_listUnits[i].gameObject);
                    _listUnits.RemoveAt(i);
                }
            }

            ProcessMessage();
        }

        public void OnLateUpdate()
        {
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                _listUnits[i].OnLateUpdate();
            }
        }

        public void ProcessMessage()
        {
            foreach (BaseMessage message in listMessages)
            { 
                if (message.MESSAGE_TYPE == MessageType.HITSTOP_REGISTER)
                {
                    Debugger.Log("hitstopmessage received by units: " + message.GetUnsignedIntMessage() + " frames");
                }
            }

            listMessages.Clear();
        }
    }
}