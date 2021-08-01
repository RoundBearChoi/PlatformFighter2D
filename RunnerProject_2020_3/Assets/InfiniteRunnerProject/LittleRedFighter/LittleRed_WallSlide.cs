using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_WallSlide : UnitState
    {
        public LittleRed_WallSlide(Unit unit)
        {
            ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_WALLSLIDE);
        }

        public override void OnEnter()
        {
            ownerUnit.unitData.rigidBody2D.velocity = new Vector2(0f, ownerUnit.unitData.rigidBody2D.velocity.y);
            ownerUnit.unitData.airControl.SetMomentum(0f);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (fixedUpdateCount >= 1)
            {
                //not touching wall
                List<Ground> sideTouchingGrounds = ownerUnit.unitData.collisionStays.GetSideTouchingGrounds();

                if (sideTouchingGrounds.Count < 2)
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Fall(ownerUnit));
                }

                //hit ground
                List<Ground> groundsEnter = ownerUnit.unitData.collisionEnters.GetTouchingGrounds(CollisionType.BOTTOM);

                if (groundsEnter.Count > 0)
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
                }

                List<Ground> groundsStay = ownerUnit.unitData.collisionStays.GetTouchingGrounds(CollisionType.BOTTOM);

                if (groundsStay.Count > 0)
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
                }
            }
        }
    }
}