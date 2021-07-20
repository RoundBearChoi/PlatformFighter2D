using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class HorizontalParallax : StateComponent
    {
        float _yPositionFix = 0f;
        float _xStartingPos = 0f;
        float _percentage = 0f;
        GameObject _parallaxAnchor = null;

        public HorizontalParallax(Unit unit, float percentage)
        {
            _unit = unit;
            _xStartingPos = unit.transform.position.x;
            _yPositionFix = unit.transform.position.y;
            _percentage = percentage;
        }

        public override void OnFixedUpdate()
        {
            if (_parallaxAnchor != null)
            {
                Vector3 pos = _parallaxAnchor.transform.position * _percentage;
                _unit.transform.position = new Vector3(_xStartingPos + pos.x, _yPositionFix, _unit.transform.position.z);
            }
            else
            {
                if (CameraScript.CURRENT_CAM != null)
                {
                    _parallaxAnchor = CameraScript.CURRENT_CAM.gameObject;
                }
            }
        }
    }
}