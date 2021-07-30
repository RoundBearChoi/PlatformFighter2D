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
            float abs = Mathf.Abs(_unit.unitData.airControl.HORIZONTAL_MOMENTUM);

            if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_LEFT))
            {
                _unit.unitData.airControl.AddMomentum(GameInitializer.current.fighterDataSO.HorizontalAirMomentumIncreaseAmount * -1f);
            }

            if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_RIGHT))
            {
                _unit.unitData.airControl.AddMomentum(GameInitializer.current.fighterDataSO.HorizontalAirMomentumIncreaseAmount);
            }

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

            _unit.unitData.rigidBody2D.velocity = new Vector2(_unit.unitData.airControl.HORIZONTAL_MOMENTUM, _unit.unitData.rigidBody2D.velocity.y);
        }
    }
}