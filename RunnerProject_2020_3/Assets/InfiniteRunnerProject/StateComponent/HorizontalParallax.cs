using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class HorizontalParallax : StateComponent
    {
        float _yPositionFix = 0f;
        float _xStartingPos = 0f;

        GameObject _parallaxAnchor = null;
        float _percentage = 0f;
       
        public HorizontalParallax(Unit unit, GameObject anchor, float percentage)
        {
            _unit = unit;
            _xStartingPos = unit.transform.position.x;
            _yPositionFix = unit.transform.position.y;
            _parallaxAnchor = anchor;
            _percentage = percentage;
        }

        public override void Update()
        {
            if (_parallaxAnchor != null)
            {
                Vector3 pos = _parallaxAnchor.transform.position * _percentage;
                _unit.transform.position = new Vector3(_xStartingPos + pos.x, _yPositionFix, _unit.transform.position.z);
            }
        }
    }
}