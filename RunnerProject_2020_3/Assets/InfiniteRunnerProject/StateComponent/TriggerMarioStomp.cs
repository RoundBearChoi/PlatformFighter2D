using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerMarioStomp : StateComponent
    {
        public TriggerMarioStomp(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            List<CollisionData> collisions = _unit.unitData.collisionEnters.GetCollisionData(CollisionType.BOTTOM);

            foreach (CollisionData col in collisions)
            {
                Unit collidingUnit = col.collidingObject.GetComponent<Unit>();

                if (collidingUnit != null)
                {
                    if (collidingUnit != _unit)
                    {
                        if (collidingUnit.unitType == UnitType.LITTLE_RED_DARK ||
                            collidingUnit.unitType == UnitType.LITTLE_RED_LIGHT)
                        {
                            _unit.unitData.listNextStates.Add(new LittleRed_Jump_Up(_unit, GameInitializer.current.fighterDataSO.JumpForce * 0.6f, false));

                            BaseMessage triggerStompedState = new Message_TriggerStompedState(collidingUnit);
                            triggerStompedState.Register();

                            BaseMessage showParryEffect = new Message_ShowParryEffect(col.contactPoint.point);
                            showParryEffect.Register();
                            break;
                        }
                    }
                }
            }
        }
    }
}