using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_Grass_DefaultState : UnitState
    {
        public static SpriteAnimationSpec animationSpec;
        public static Swamp_Grass_DefaultState latest;

        public Swamp_Grass_DefaultState(Unit unit)
        {
            _unit = unit;
            latest = this;

            _listStateComponents.Add(new HorizontalParallax(unit, unit.transform.position, GameInitializer.current.swampParallaxSO.Swamp_Grass_ParallaxPercentage));
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            //testing latest sprite edges
            Vector2[] latest_edges = latest._unit.unitData.spriteAnimations.currentAnimation.GetSpriteWorldEdges(0);

            //foreach(Vector2 edge in latest_edges)
            //{
            //    Debug.DrawLine(Vector3.zero, edge, Color.blue, 0.1f);
            //}

            if (latest_edges[3].x < CameraScript.current.cameraEdges.GetEdges()[3].x)
            {
                Debugger.Log("latest grass edge inside frustum");
            }

            //testing this sprite edges
            Vector2[] edges = _unit.unitData.spriteAnimations.currentAnimation.GetSpriteWorldEdges(0);

            if (edges[3].x < CameraScript.current.cameraEdges.GetEdges()[0].x)
            {
                Debugger.Log("outside frustum: " + _unit.gameObject.name);
                _unit.destroy = true;
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}