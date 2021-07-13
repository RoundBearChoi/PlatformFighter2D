using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem_Wincing : State
    {
        public static SpriteAnimationSpec animationSpec = null;

        private bool _initialPushBack = false;
        private Material _defaultMaterial = null;
        //private Vector3 _originalSpriteLocalPosition;

        public Golem_Wincing(Unit unit)
        {
            _unit = unit;
        }

        public override void OnEnter()
        {
            //_originalSpriteLocalPosition = _unit.unitData.spriteAnimations.currentAnimation.RENDERER.transform.localPosition;
        }

        public override void OnFixedUpdate()
        {
            if (!_initialPushBack)
            {
                _initialPushBack = true;
                _unit.unitData.rigidBody2D.velocity = ((_unit.transform.right * 3.5f * -1f) + (Vector3.up * 2.75f));
            }

            if (_defaultMaterial == null)
            {
                _defaultMaterial = _unit.unitData.spriteAnimations.currentAnimation.RENDERER.sharedMaterial;
                _unit.unitData.spriteAnimations.currentAnimation.RENDERER.sharedMaterial = GameInitializer.current.white_GUIText_material;
            }

            //if (updateCount < 8)
            //{
            //    _unit.unitData.spriteAnimations.currentAnimation.RENDERER.transform.localPosition = new Vector3(
            //        _originalSpriteLocalPosition.x + Random.Range(-0.2f, 0.2f),
            //        _originalSpriteLocalPosition.y,
            //        _originalSpriteLocalPosition.z);
            //}
            //else
            //{
            //    _unit.unitData.spriteAnimations.currentAnimation.RENDERER.transform.localPosition = _originalSpriteLocalPosition;
            //}

            if (updateCount > 8)
            {
                _unit.unitData.spriteAnimations.currentAnimation.RENDERER.sharedMaterial = _defaultMaterial;
            }

            if (_unit.unitData.collisionStays.IsOnFlatGround())
            {
                _unit.unitData.rigidBody2D.velocity = Vector2.Lerp(_unit.unitData.rigidBody2D.velocity, Vector2.zero, 0.1f);
            }

            if (updateCount >= 20)
            {
                _unit.unitData.listNextStates.Add(new Golem_Idle(_unit));
            }
        }

        public override void OnExit()
        {

        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}