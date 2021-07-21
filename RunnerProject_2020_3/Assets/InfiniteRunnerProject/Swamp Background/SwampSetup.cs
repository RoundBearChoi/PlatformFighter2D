using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SwampSetup : IBackgroundSetup
    {
        public void InstantiateBaseLayer()
        {
            Stage.currentStage.InstantiateUnits_ByUnitType(UnitType.SWAMP);
        }

        public Unit InstantiateAdditionalBackgroundUnit<T>()
        {
            Unit prevUnit = Stage.currentStage.units.GetLatestUnitByState<T>();

            if (prevUnit != null)
            {
                //use existing background (same type)
                SpriteAnimationSpec spriteSpec = prevUnit.iStateController.GetCurrentState().GetSpriteAnimationSpec();
                SpriteAnimation animation = prevUnit.unitData.spriteAnimations.GetLastSpriteAnimation();

                //existing specs
                Vector2 worldSize = animation.GetSpriteWorldSize(0);

                Stage.currentStage.InstantiateUnit_BySpriteAnimationSpec(spriteSpec);
                Unit newGrass = Stage.currentStage.units.GetLatestUnitByState<T>();
                newGrass.transform.position = new Vector3(prevUnit.transform.position.x + worldSize.x, prevUnit.transform.position.y, prevUnit.transform.position.z);
                Stage.currentStage.units.AddUnit(newGrass);

                return newGrass;
            }
            else
            {
                return null;
            }
        }

        public void AddAdditionalBackground<T>() where T: UnitState
        {
            Unit additionalBackground = InstantiateAdditionalBackgroundUnit<T>();
            Camera cam = CameraScript.current.GetCamera();

            if (typeof(T) == typeof(Swamp_Grass_DefaultState))
            {
                //negate existing camera offset
                float offsetX = cam.transform.position.x * GameInitializer.current.swampParallaxSO.Swamp_Grass_ParallaxPercentage;
                additionalBackground.transform.position -= new Vector3(offsetX, 0f, 0f);
                additionalBackground.iStateController.SetNewState(new Swamp_Grass_DefaultState(additionalBackground));
            }
            else if (typeof(T) == typeof(Swamp_River_DefaultState))
            {
                float offsetX = cam.transform.position.x * GameInitializer.current.swampParallaxSO.Swamp_River_ParallaxPercentage;
                additionalBackground.transform.position -= new Vector3(offsetX, 0f, 0f);
                additionalBackground.iStateController.SetNewState(new Swamp_River_DefaultState(additionalBackground));
            }
            else if (typeof(T) == typeof(Swamp_FrontTrees_DefaultState))
            {
                float offsetX = cam.transform.position.x * GameInitializer.current.swampParallaxSO.Swamp_FrontTrees_ParallaxPercentage;
                additionalBackground.transform.position -= new Vector3(offsetX, 0f, 0f);
                additionalBackground.iStateController.SetNewState(new Swamp_FrontTrees_DefaultState(additionalBackground));
            }
            else if (typeof(T) == typeof(Swamp_BackTrees_DefaultState))
            {
                float offsetX = cam.transform.position.x * GameInitializer.current.swampParallaxSO.Swamp_BackTrees_ParallaxPercentage;
                additionalBackground.transform.position -= new Vector3(offsetX, 0f, 0f);
                additionalBackground.iStateController.SetNewState(new Swamp_BackTrees_DefaultState(additionalBackground));
            }
        }
    }
}