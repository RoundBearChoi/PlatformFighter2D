using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_Grass_DefaultState : UnitState
    {
        public static SpriteAnimationSpec animationSpec;

        public Swamp_Grass_DefaultState(Unit unit)
        {
            _unit = unit;

            _listStateComponents.Add(new HorizontalParallax(unit, unit.transform.position, GameInitializer.current.swampParallaxSO.Swamp_Grass_ParallaxPercentage));
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            //testing
            Vector2[] edges = _unit.unitData.spriteAnimations.currentAnimation.GetSpriteWorldEdges(0);

            foreach(Vector2 edge in edges)
            {
                Debug.DrawLine(Vector3.zero, edge, Color.blue, 0.1f);
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}