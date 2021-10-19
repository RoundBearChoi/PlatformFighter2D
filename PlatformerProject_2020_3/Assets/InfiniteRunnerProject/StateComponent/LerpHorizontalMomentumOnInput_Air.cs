using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LerpHorizontalMomentumOnInput_Air : StateComponent
    {
        private float _maxMomentum = 0f;

        public LerpHorizontalMomentumOnInput_Air(UnitState unitState, float maxMomentum)
        {
            _unitState = unitState;
            _maxMomentum = maxMomentum;
        }

        public override void OnFixedUpdate()
        {
            if (!UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.BOTTOM) && !UNIT_DATA.collisionEnters.IsTouchingGround(CollisionType.BOTTOM))
            {
                float abs = Mathf.Abs(UNIT_DATA.airControl.HORIZONTAL_MOMENTUM);

                if (abs >= _maxMomentum)
                {
                    if (UNIT_DATA.airControl.HORIZONTAL_MOMENTUM < 0)
                    {
                        UNIT_DATA.airControl.SetMomentum(_maxMomentum * -1f);
                    }
                    else if (UNIT_DATA.airControl.HORIZONTAL_MOMENTUM > 0)
                    {
                        UNIT_DATA.airControl.SetMomentum(_maxMomentum);
                    }
                }

                if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false))
                {
                    UNIT_DATA.airControl.AddMomentum(BaseInitializer.CURRENT.fighterDataSO.HorizontalAirMomentumIncreaseAmount * -1f);
                }

                if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false))
                {
                    UNIT_DATA.airControl.AddMomentum(BaseInitializer.CURRENT.fighterDataSO.HorizontalAirMomentumIncreaseAmount);
                }
            }

            //reset momentum when on ground
            else if (UNIT_DATA.collisionStays.IsOnFlatGround())
            {
                ResetMomentum();
            }
        }

        void ResetMomentum()
        {
            if (UNIT_DATA.facingRight)
            {
                UNIT_DATA.airControl.SetMomentum(0.001f);
            }
            else
            {
                UNIT_DATA.airControl.SetMomentum(-0.001f);
            }
        }
    }
}