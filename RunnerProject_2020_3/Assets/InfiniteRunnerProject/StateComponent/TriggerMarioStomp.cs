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

                            //BaseMessage showParryEffect = new Message_ShowParryEffect(new Vector3(col.contactPoint.point.x, col.contactPoint.point.y, GameInitializer.current.fighterDataSO.ParryEffects_z));
                            //showParryEffect.Register();

                            BaseMessage stepDustRight = new Message_ShowStepDust(true, new Vector3(col.contactPoint.point.x + 0.25f, col.contactPoint.point.y - 0.42f, GameInitializer.current.fighterDataSO.DustEffects_z), 3);
                            stepDustRight.Register();

                            BaseMessage stepDustLeft = new Message_ShowStepDust(false, new Vector3(col.contactPoint.point.x - 0.25f, col.contactPoint.point.y - 0.42f, GameInitializer.current.fighterDataSO.DustEffects_z), 3);
                            stepDustLeft.Register();
                            break;
                        }
                    }
                }
            }
        }
    }
}