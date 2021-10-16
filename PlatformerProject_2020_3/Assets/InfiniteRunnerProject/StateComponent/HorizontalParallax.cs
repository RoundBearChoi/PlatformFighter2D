using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class HorizontalParallax : StateComponent
    {
        CameraScript _cameraScript = null;
        Vector2 _basePos = Vector2.zero;
        float _percentage = 0f;
        GameObject _parallaxAnchor = null;
        
        public HorizontalParallax(CameraScript cameraScript, Unit unit, Vector2 basePos, float percentage)
        {
            _cameraScript = cameraScript;
            _parallaxAnchor = _cameraScript.GetCamera().gameObject;
            _unit = unit;
            _basePos = basePos;
            _percentage = percentage;
        }

        public override void OnFixedUpdate()
        {
            Vector3 pos = _parallaxAnchor.transform.position * _percentage;
            _unit.transform.position = new Vector3(_basePos.x + pos.x, _unit.transform.position.y, _unit.transform.position.z);
        }
    }
}