using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class HorizontalParallax : StateComponent
    {
        Vector2 _basePos = Vector2.zero;
        float _percentage = 0f;
        
        public HorizontalParallax(UnitState unitState, Vector2 basePos, float percentage)
        {
            _unitState = unitState;
            _basePos = basePos;
            _percentage = percentage;
        }

        public override void OnFixedUpdate()
        {
            Vector3 pos = UNIT.OWNER_STAGE.CAMERA_SCRIPT.CAMERA.transform.position * _percentage;
            UNIT.transform.position = new Vector3(_basePos.x + pos.x, UNIT.transform.position.y, UNIT.transform.position.z);
        }
    }
}