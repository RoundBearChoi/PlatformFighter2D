using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LerpHorizontalMomentumOnInput_Air : StateComponent
    {
        private float _maxMomentum = 0f;

        public LerpHorizontalMomentumOnInput_Air(Unit unit, float maxMomentum)
        {
            _unit = unit;
            _maxMomentum = maxMomentum;
        }

        public override void OnFixedUpdate()
        {
            if (!_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM) && !_unit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM))
            {
                float abs = Mathf.Abs(_unit.unitData.airControl.HORIZONTAL_MOMENTUM);

                if (abs >= _maxMomentum)
                {
                    if (_unit.unitData.airControl.HORIZONTAL_MOMENTUM < 0)
                    {
                        _unit.unitData.airControl.SetMomentum(_maxMomentum * -1f);
                    }
                    else if (_unit.unitData.airControl.HORIZONTAL_MOMENTUM > 0)
                    {
                        _unit.unitData.airControl.SetMomentum(_maxMomentum);
                    }
                }

                if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_LEFT))
                {
                    _unit.unitData.airControl.AddMomentum(BaseInitializer.current.fighterDataSO.HorizontalAirMomentumIncreaseAmount * -1f);
                }

                if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_RIGHT))
                {
                    _unit.unitData.airControl.AddMomentum(BaseInitializer.current.fighterDataSO.HorizontalAirMomentumIncreaseAmount);
                }
            }

            //reset momentum when on ground
            else if (_unit.unitData.collisionStays.IsOnFlatGround())
            {
                _unit.unitData.airControl.SetMomentum(0f);
            }
        }
    }
}