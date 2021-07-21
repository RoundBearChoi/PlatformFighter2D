using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class AddBackground<T> : StateComponent where T : UnitState
    {
        public AddBackground(Unit unit)
        {
            _unit = unit;
        }

        public override void OnUpdate()
        {
            //testing latest sprite edges
            //if (_latest.ownerUnit.unitData.spriteAnimations.currentAnimation != null)
            //{
            //    Vector2[] latest_edges = _latest.ownerUnit.unitData.spriteAnimations.currentAnimation.GetSpriteWorldEdges(0);
            //
            //    foreach (Vector2 edge in latest_edges)
            //    {
            //        Debug.DrawLine(Vector3.zero, edge, Color.blue, 0.1f);
            //    }
            //
            //    if (latest_edges[3].x < CameraScript.current.cameraEdges.GetEdges()[3].x + 5f)
            //    {
            //        Debugger.Log("latest grass edge inside frustum");
            //        Stage.currentStage.backgroundSetup.AddAdditionalBackground<Swamp_Grass_DefaultState>();
            //    }
            //}
        }
    }
}