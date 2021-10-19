using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CreateRenderTrail : StateComponent
    {
        private int _totalTrails = 0;
        private bool _faceRight = true;

        public CreateRenderTrail(UnitState unitState, int totalTrails, bool faceRight)
        {
            _unitState = unitState;
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
                trail.gameObject.name = "trail - " + UNIT.gameObject.name;
                trail.transform.SetParent(BaseInitializer.CURRENT.STAGE.transform, false);

                trail.spriteRenderer = trailObj.AddComponent<SpriteRenderer>();
                trail.spriteRenderer.sprite = UNIT.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.sprite;

                trail.rootUnit = UNIT;

                trail.spriteRenderer.transform.position = UNIT.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.transform.position;
                trail.spriteRenderer.transform.localScale = UNIT.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.transform.localScale;
                trail.spriteRenderer.transform.localRotation = UNIT.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.transform.localRotation;

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

                BaseInitializer.CURRENT.STAGE.trailEffects.AddTrail(trail);
            }
        }
    }
}