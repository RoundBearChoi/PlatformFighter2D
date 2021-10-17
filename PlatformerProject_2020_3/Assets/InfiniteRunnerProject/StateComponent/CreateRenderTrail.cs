using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CreateRenderTrail : StateComponent
    {
        private int _totalTrails = 0;
        private bool _faceRight = true;

        public CreateRenderTrail(Unit unit, int totalTrails, bool faceRight)
        {
            _unit = unit;
            _totalTrails = totalTrails;
            _faceRight = faceRight;
        }

        public override void OnFixedUpdate()
        {
            if (_totalTrails > 0)
            {
                _totalTrails--;

                GameObject trailObj = new GameObject();

                TrailEffect trail = trailObj.AddComponent<TrailEffect>();
                trail.gameObject.name = "trail - " + _unit.gameObject.name;
                trail.transform.SetParent(BaseInitializer.current.STAGE.transform, false);

                trail.spriteRenderer = trailObj.AddComponent<SpriteRenderer>();
                trail.spriteRenderer.sprite = _unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.sprite;

                trail.rootUnit = _unit;

                trail.spriteRenderer.transform.position = _unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.transform.position;
                trail.spriteRenderer.transform.localScale = _unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.transform.localScale;
                trail.spriteRenderer.transform.localRotation = _unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.transform.localRotation;

                if (_faceRight)
                {
                    if (trail.spriteRenderer.transform.rotation.y != 0f)
                    {
                        trail.spriteRenderer.transform.rotation = Quaternion.Euler(trail.spriteRenderer.transform.rotation.x, 0f, trail.spriteRenderer.transform.rotation.z);
                    }
                }
                else
                {
                    if (trail.spriteRenderer.transform.rotation.y != 180f)
                    {
                        trail.spriteRenderer.transform.rotation = Quaternion.Euler(trail.spriteRenderer.transform.rotation.x, 180f, trail.spriteRenderer.transform.rotation.z);
                    }
                }

                BaseInitializer.current.STAGE.trailEffects.AddTrail(trail);
            }
        }
    }
}