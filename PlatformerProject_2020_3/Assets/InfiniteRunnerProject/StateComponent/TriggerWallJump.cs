using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerWallJump : StateComponent
    {
        public TriggerWallJump(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            //wall jump
            if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.JUMP, true))
            {
                float initialMomentum = BaseInitializer.CURRENT.fighterDataSO.WallJumpHorizontalMomentum;

                if (UNIT_DATA.facingRight)
                {
                    initialMomentum *= -1f;
                }

                //show walljump dust
                List<CollisionData> sideCollisions = UNIT_DATA.collisionStays.GetSideCollisionData();

                float x = 0f;
                float y = 0f;

                foreach (CollisionData data in sideCollisions)
                {
                    if (data.collidingObject.GetComponent<Ground>() != null)
                    {
                        x = data.contactPoint.point.x;
                        y = UNIT.transform.position.y + 1f;

                        Vector3 dustPosition = new Vector3(x, y, BaseInitializer.CURRENT.fighterDataSO.DustEffects_z);

                        if (!UNIT.isDummy)
                        {
                            BaseMessage showWallJumpDust = new Message_ShowWallJumpDust(UNIT_DATA.facingRight, dustPosition, new Vector2(1f, 1f));
                            showWallJumpDust.Register();
                        }

                        UNIT_DATA.airControl.SetMomentum(initialMomentum);
                        UNIT_DATA.listNextStates.Add(new LittleRed_Jump_Up(BaseInitializer.CURRENT.fighterDataSO.WallJumpForce, 0));

                        break;
                    }
                }
            }
        }
    }
}
