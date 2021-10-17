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
            List<CollisionData> enters = _unit.unitData.collisionEnters.GetCollisionData(CollisionType.BOTTOM);
            List<CollisionData> stays = _unit.unitData.collisionStays.GetCollisionData(CollisionType.BOTTOM);

            DoStomp(enters);
            DoStomp(stays);
        }

        void DoStomp(List<CollisionData> collisions)
        {
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
                            _unit.unitData.listNextStates.Add(new LittleRed_Jump_Up(_unit,
                                BaseInitializer.CURRENT.fighterDataSO.VerticalJumpForce * BaseInitializer.CURRENT.fighterDataSO.VerticalJumpForceMultiplierOnMarioStomp,
                                BaseInitializer.CURRENT.fighterDataSO.DefaultJumpFramesOnMarioStomp));

                            BaseMessage triggerStompedState = new Message_TriggerStompedState(collidingUnit);
                            triggerStompedState.Register();

                            //BaseMessage showParryEffect = new Message_ShowParryEffect(new Vector3(col.contactPoint.point.x, col.contactPoint.point.y, GameInitializer.current.fighterDataSO.ParryEffects_z));
                            //showParryEffect.Register();

                            Vector2 scaleMultiplier = new Vector2(1.35f, 1.35f);

                            if (!_unit.isDummy)
                            {
                                BaseMessage stepDustRight = new Message_ShowStepDust(
                                    true,
                                    new Vector3(col.contactPoint.point.x + 0.15f, col.contactPoint.point.y - 0.3f, BaseInitializer.CURRENT.fighterDataSO.DustEffects_z),
                                    scaleMultiplier,
                                    3);
                                stepDustRight.Register();

                                BaseMessage stepDustLeft = new Message_ShowStepDust(
                                    false,
                                    new Vector3(col.contactPoint.point.x - 0.15f, col.contactPoint.point.y - 0.3f, BaseInitializer.CURRENT.fighterDataSO.DustEffects_z),
                                    scaleMultiplier,
                                    3);
                                stepDustLeft.Register();
                            }

                            break;
                        }
                    }
                }
            }
        }
    }
}