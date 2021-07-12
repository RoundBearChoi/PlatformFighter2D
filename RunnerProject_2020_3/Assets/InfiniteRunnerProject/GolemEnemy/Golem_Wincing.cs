using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem_Wincing : State
    {
        public static SpriteAnimationSpec animationSpec = null;

        private bool _initialPushBack = false;

        public Golem_Wincing(Unit unit)
        {
            _unit = unit;
            
        }

        public override void OnFixedUpdate()
        {
            if (!_initialPushBack)
            {
                _initialPushBack = true;
                _unit.unitData.rigidBody2D.velocity = ((_unit.transform.right * 3.5f * -1f) + (Vector3.up * 2.75f));
            }

            if (GroundCheck.IsOnFlatGround((_unit.unitData.collisionStays)))
            {
                _unit.unitData.rigidBody2D.velocity = Vector2.Lerp(_unit.unitData.rigidBody2D.velocity, Vector2.zero, 0.1f);
            }

            if (updateCount >= 30)
            {
                _unit.unitData.listNextStates.Add(new Golem_Idle(_unit));
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}