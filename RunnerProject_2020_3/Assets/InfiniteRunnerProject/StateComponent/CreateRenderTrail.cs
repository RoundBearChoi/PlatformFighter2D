using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CreateRenderTrail : StateComponent
    {
        private int _totalTrails = 0;

        public CreateRenderTrail(Unit unit, int totalTrails)
        {
            _unit = unit;
            _totalTrails = totalTrails;
        }

        public override void OnFixedUpdate()
        {
            if (_totalTrails > 0)
            {
                _totalTrails--;

                GameObject trailObj = new GameObject();

                TrailEffect trail = trailObj.AddComponent<TrailEffect>();
                trail.gameObject.name = "trail - " + _unit.gameObject.name;
                trail.gameObject.transform.position = _unit.gameObject.transform.position;
                trail.gameObject.transform.rotation = Quaternion.identity;
                trail.transform.parent = Stage.currentStage.transform;

                trail.spriteRenderer = trailObj.AddComponent<SpriteRenderer>();
                trail.spriteRenderer.sprite = _unit.unitData.spriteAnimations.currentAnimation.RENDERER.sprite;

                trail.spriteRenderer.transform.localPosition = _unit.unitData.spriteAnimations.currentAnimation.RENDERER.transform.position;
                trail.spriteRenderer.transform.localScale = _unit.unitData.spriteAnimations.currentAnimation.RENDERER.transform.localScale;
                trail.spriteRenderer.transform.localRotation = _unit.unitData.spriteAnimations.currentAnimation.RENDERER.transform.localRotation;
            }
        }
    }
}