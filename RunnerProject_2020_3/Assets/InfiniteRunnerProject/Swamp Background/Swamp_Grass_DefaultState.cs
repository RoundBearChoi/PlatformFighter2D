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
            Vector2[] edges = latest._unit.unitData.spriteAnimations.currentAnimation.GetSpriteWorldEdges(0);

            foreach(Vector2 edge in edges)
            {
                Debug.DrawLine(Vector3.zero, edge, Color.blue, 0.1f);
            }

            if (edges[3].x < CameraScript.current.cameraEdges.GetEdges()[3].x)
            {
                Debugger.Log("latest grass edge inside frustum");
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}