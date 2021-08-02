using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DeletePassedGround : StateComponent
    {
        CameraScript _cameraScript = null;

        public DeletePassedGround(Unit unit)
        {
            _unit = unit;
            _cameraScript = BaseInitializer.current.GetStage().cameraScript;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.iStateController.GetCurrentState().fixedUpdateCount >= 1)
            {
                Vector3 topRight = _unit.unitData.compositeCollider2D.bounds.center + (_unit.unitData.compositeCollider2D.bounds.size * 0.5f);

                if (topRight.x < _cameraScript.cameraEdges.GetEdges()[0].x - 5f)
                {
                    Debugger.Log("outside frustum: " + _unit.gameObject.name);
                    _unit.destroy = true;
                }
            }
        }
    }
}