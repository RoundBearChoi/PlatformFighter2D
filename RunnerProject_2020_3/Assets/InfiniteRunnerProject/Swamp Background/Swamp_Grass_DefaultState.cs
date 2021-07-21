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
            ownerUnit = unit;
            latest = this;

            _listStateComponents.Add(new HorizontalParallax(unit, unit.transform.position, GameInitializer.current.swampParallaxSO.Swamp_Grass_ParallaxPercentage));
            _listStateComponents.Add(new DeletePassedBackground(unit));
            //_listStateComponents.Add(new AddBackground<Swamp_Grass_DefaultState>(unit));
        }

        public override void OnUpdate()
        {
            UpdateComponents();

            //testing latest sprite edges
            if (latest.ownerUnit.unitData.spriteAnimations.currentAnimation != null)
            {
                Vector2[] latest_edges = latest.ownerUnit.unitData.spriteAnimations.currentAnimation.GetSpriteWorldEdges(0);
            
                foreach (Vector2 edge in latest_edges)
                {
                    Debug.DrawLine(Vector3.zero, edge, Color.blue, 0.1f);
                }
            
                if (latest_edges[3].x < CameraScript.current.cameraEdges.GetEdges()[3].x + 5f)
                {
                    Debugger.Log("latest grass edge inside frustum");
                    Stage.currentStage.backgroundSetup.AddAdditionalBackground<Swamp_Grass_DefaultState>();
                }
            }
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}