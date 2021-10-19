using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Fall : UnitState
    {
        public Runner_Jump_Fall()
        {
            _listStateComponents.Add(new TriggerAirDownSmash(this));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_JUMP_FALL);
        }

        public override void OnEnter()
        {

        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                BaseMessage showLandingDust = new Message_ShowLandingDust(true, _ownerUnit.transform.position, new Vector2(1f, 1f));
                showLandingDust.Register();

                _ownerUnit.listNextStates.Add(new Runner_NormalRun());
            }
        }
    }
}