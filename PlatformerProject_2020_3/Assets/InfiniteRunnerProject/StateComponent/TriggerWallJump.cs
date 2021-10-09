using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerWallJump : StateComponent
    {
        public TriggerWallJump(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            //wall jump
            if (_unit.USER_INPUT.commands.ContainsPress(CommandType.JUMP, true))
            {
                float initialMomentum = BaseInitializer.current.fighterDataSO.WallJumpHorizontalMomentum;

                if (_unit.unitData.facingRight)
                {
                    initialMomentum *= -1f;
                }

                //show walljump dust
                List<CollisionData> sideCollisions = _unit.unitData.collisionStays.GetSideCollisionData();

                float x = 0f;
                float y = 0f;

                foreach (CollisionData data in sideCollisions)
                {
                    if (data.collidingObject.GetComponent<Ground>() != null)
                    {
                        x = data.contactPoint.point.x;
                        y = _unit.transform.position.y + 1f;

                        Vector3 dustPosition = new Vector3(x, y, BaseInitializer.current.fighterDataSO.DustEffects_z);

                        if (!_unit.isDummy)
                        {
                            BaseMessage showWallJumpDust = new Message_ShowWallJumpDust(_unit.unitData.facingRight, dustPosition, new Vector2(1f, 1f));
                            showWallJumpDust.Register();
                        }

                        _unit.unitData.airControl.SetMomentum(initialMomentum);
                        _unit.unitData.listNextStates.Add(new LittleRed_Jump_Up(_unit, BaseInitializer.current.fighterDataSO.WallJumpForce, 0));

                        break;
                    }
                }
            }
        }
    }
}
