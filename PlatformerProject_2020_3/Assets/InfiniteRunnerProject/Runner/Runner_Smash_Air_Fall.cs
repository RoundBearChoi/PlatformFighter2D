using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Smash_Air_Fall : UnitState
    {
        public Runner_Smash_Air_Fall(Unit unit)
        {
            _ownerUnit = unit;
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 0f, 0.05f));
            _listStateComponents.Add(new AddCumulativeVelocity(this, 1.3f));

            _ownerUnit.gameObject.layer = (int)LayerType.GHOSTING_UNIT;

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_SMASH_AIR_FALL);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_ownerUnit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM) || _ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                BaseMessage showSmashDust = new Message_ShowSmashDust(true, _ownerUnit.transform.position);
                showSmashDust.Register();

                _ownerUnit.listNextStates.Add(new Runner_Smash_Air_Land(_ownerUnit));
            }
        }
    }
}