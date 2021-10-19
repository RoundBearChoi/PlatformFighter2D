using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerWallSlideDust : StateComponent
    {
        public TriggerWallSlideDust(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            uint fixedUpdateCount = UNIT.iStateController.GetCurrentState().fixedUpdateCount;

            if (fixedUpdateCount != 0 && fixedUpdateCount % UNIT.spriteAnimations.GetCurrentAnimation().SPRITE_INTERVAL == 0)
            {
                if (UNIT.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 1 ||
                    UNIT.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 2)
                {
                    float x = 0f;
                    float y = 0f;

                    List<CollisionData> sideCollisions = UNIT_DATA.collisionStays.GetSideCollisionData();

                    foreach (CollisionData data in sideCollisions)
                    {
                        if (data.collidingObject.GetComponent<Ground>() != null)
                        {
                            x = data.contactPoint.point.x;
                            break;
                        }
                    }

                    y = UNIT.transform.position.y + 1.5f;

                    Vector3 dustPosition = new Vector3(x, y, BaseInitializer.CURRENT.fighterDataSO.DustEffects_z);

                    if (!UNIT.isDummy)
                    {
                        BaseMessage showWallSlideDust = new Message_ShowWallSlideDust(UNIT.facingRight, dustPosition, new Vector2(1f, 1f));
                        showWallSlideDust.Register();
                    }
                }
            }
        }
    }
}