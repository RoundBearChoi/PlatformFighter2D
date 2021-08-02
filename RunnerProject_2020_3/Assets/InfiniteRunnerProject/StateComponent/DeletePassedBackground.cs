using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DeletePassedBackground : StateComponent
    {
        CameraScript _cameraScript = null;

        public DeletePassedBackground(Unit unit)
        {
            _unit = unit;
            _cameraScript = BaseInitializer.current.GetStage().cameraScript;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.iStateController.GetCurrentState().fixedUpdateCount >= 1)
            {
                if (_unit.unitData.spriteAnimations.GetCurrentAnimation() != null)
                {
                    Vector2[] edges = _unit.unitData.spriteAnimations.GetCurrentAnimation().GetSpriteWorldEdges(0);

                    if (edges[3].x < _cameraScript.cameraEdges.GetEdges()[0].x - 5f)
                    {
                        Debugger.Log("outside frustum: " + _unit.gameObject.name);
                        _unit.destroy = true;
                    }
                }
            }
        }
    }
}