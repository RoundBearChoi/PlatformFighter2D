using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerWallSlideDust : StateComponent
    {
        public TriggerWallSlideDust(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            uint fixedUpdateCount = _unit.iStateController.GetCurrentState().fixedUpdateCount;

            if (fixedUpdateCount != 0 && fixedUpdateCount % _unit.unitData.spriteAnimations.GetCurrentAnimation().animationSpec.spriteInterval == 0)
            {
                if (_unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 1 ||
                    _unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 2)
                {
                    float x = 0f;
                    float y = 0f;

                    List<CollisionData> sideCollisions = _unit.unitData.collisionStays.GetSideCollisionData();

                    foreach (CollisionData data in sideCollisions)
                    {
                        if (data.collidingObject.GetComponent<Ground>() != null)
                        {
                            x = data.contactPoint.point.x;
                            break;
                        }
                    }

                    y = _unit.transform.position.y + 1.5f;

                    Vector3 dustPosition = new Vector3(x, y, BaseInitializer.current.fighterDataSO.DustEffects_z);

                    BaseMessage showWallSlideDust = new ShowWallSlideDust_Message(_unit.unitData.facingRight, dustPosition, new Vector2(1f, 1f));
                    showWallSlideDust.Register();
                }
            }
        }
    }
}