using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_AttackA_Slash : State
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_AttackA_Slash(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            _unit.unitData.rigidBody2D.mass = 0.001f;

            float force = 100f;

            if (!_unit.unitData.facingRight)
            {
                force *= -1f;
            }

            //temp trail
            if (updateCount == 0)
            {
                GameObject trailObj = new GameObject();

                TrailEffect trail = trailObj.AddComponent<TrailEffect>();
                trail.gameObject.name = "trail - " + _unit.gameObject.name;
                trail.gameObject.transform.position = _unit.gameObject.transform.position;
                trail.gameObject.transform.rotation = Quaternion.identity;
                trail.transform.parent = Stage.currentStage.transform;

                SpriteRenderer spriteRenderer = trailObj.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = _unit.unitData.spriteAnimations.currentAnimation.RENDERER.sprite;
            }

            if (updateCount <= 2)
            {
                _unit.unitData.rigidBody2D.velocity = new Vector2(100f, 0f);
            }
            else
            {
                _unit.unitData.rigidBody2D.velocity = Vector2.zero;
                _unit.unitData.rigidBody2D.mass = 1f;
                _unit.unitData.listNextStates.Add(new Runner_AttackA(_unit));
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}