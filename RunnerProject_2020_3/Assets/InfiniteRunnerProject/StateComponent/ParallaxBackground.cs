using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ParallaxBackground : StateComponent
    {
        GameObject _parallaxAnchor = null;
        float _percentage = 0f;
        
        public ParallaxBackground(Unit unit, GameObject anchor, float percentage)
        {
            _unit = unit;
            _parallaxAnchor = anchor;
            _percentage = percentage;
        }

        public override void Update()
        {
            if (_parallaxAnchor != null)
            {
                Vector3 pos = _parallaxAnchor.transform.position * _percentage;
                _unit.transform.position = new Vector3(pos.x, 0f, _unit.transform.position.z);
            }
        }
    }
}