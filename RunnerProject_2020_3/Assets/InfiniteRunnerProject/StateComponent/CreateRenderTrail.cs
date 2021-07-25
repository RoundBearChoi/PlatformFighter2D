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
                trail.transform.SetParent(GameInitializer.current.STAGE.transform, false);

                trail.spriteRenderer = trailObj.AddComponent<SpriteRenderer>();
                trail.spriteRenderer.sprite = _unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.sprite;

                trail.rootUnit = _unit;

                trail.spriteRenderer.transform.position = _unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.transform.position;
                trail.spriteRenderer.transform.localScale = _unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.transform.localScale;
                trail.spriteRenderer.transform.localRotation = _unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.transform.localRotation;

                GameInitializer.current.STAGE.trailEffects.AddTrail(trail);
            }
        }
    }
}