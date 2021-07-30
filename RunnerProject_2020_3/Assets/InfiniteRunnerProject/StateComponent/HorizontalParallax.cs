using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class HorizontalParallax : StateComponent
    {
        Vector2 _basePos = Vector2.zero;
        float _percentage = 0f;
        GameObject _parallaxAnchor = null;
        CameraScript _cameraScript = null;

        public HorizontalParallax(Unit unit, Vector2 basePos, float percentage)
        {
            _unit = unit;
            _basePos = basePos;
            _percentage = percentage;
        }

        public override void OnFixedUpdate()
        {
            if (_parallaxAnchor != null)
            {
                Vector3 pos = _parallaxAnchor.transform.position * _percentage;
                _unit.transform.position = new Vector3(_basePos.x + pos.x, _basePos.y, _unit.transform.position.z);
            }
            else
            {
                if (_cameraScript == null)
                {
                    _cameraScript = GameInitializer.current.GetStage().cameraScript;
                }

                if (_cameraScript.GetCamera() != null)
                {
                    _parallaxAnchor = _cameraScript.GetCamera().gameObject;
                }
            }
        }
    }
}