using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class AddFlatGround : StateComponent
    {
        UnitState _state = null;
        CameraScript _cameraScript;

        public AddFlatGround(CameraScript cameraScript, UnitState state)
        {
            _state = state;
            _cameraScript = cameraScript;
        }

        public override void OnFixedUpdate()
        {
            if (_state.fixedUpdateCount >= 1)
            {
                UnitState latest = _state.GetLastestInstantiatedState();

                //only check if i'm the latest state
                if (latest != null)
                {
                    if (latest == _state)
                    {
                        Vector3 topRight = latest.ownerUnit.unitData.compositeCollider2D.bounds.center + (latest.ownerUnit.unitData.compositeCollider2D.bounds.size * 0.5f);

                        Debug.DrawLine(new Vector3(0f, -5f, 0f), topRight, Color.cyan, 0.05f);

                        if (topRight.x <= _cameraScript.cameraEdges.GetEdges()[3].x + BaseInitializer.current.runnerDataSO.GroundCreationCushionX)
                        {
                            Debugger.Log("ground edge inside frustum");
                            BaseInitializer.current.GetStage().groundSetup.AddAdditionalAdjacentUnit<FlatGround_DefaultState>();
                        }
                    }
                }
            }
        }
    }
}