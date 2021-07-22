using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DeletePassedBackground : StateComponent
    {
        public DeletePassedBackground(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.spriteAnimations.GetCurrentAnimation() != null)
            {
                Vector2[] edges = _unit.unitData.spriteAnimations.GetCurrentAnimation().GetSpriteWorldEdges(0);

                if (edges[3].x < CameraScript.current.cameraEdges.GetEdges()[0].x - 5f)
                {
                    Debugger.Log("outside frustum: " + _unit.gameObject.name);
                    _unit.destroy = true;
                }
            }
        }
    }
}