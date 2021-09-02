using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SwampSetup : IBackgroundSetup
    {
        CameraScript _cameraScript = null;

        public SwampSetup()
        {
            _cameraScript = BaseInitializer.current.GetStage().cameraScript;
        }

        public void InstantiateBaseLayer()
        {
            BaseInitializer.current.GetStage().InstantiateUnits_ByUnitType(UnitType.SWAMP);
        }

        public Unit InstantiateAdditionalBackgroundUnit<T>()
        {
            Unit prevUnit = BaseInitializer.current.GetStage().units.GetLatestUnitByState<T>();
            
            if (prevUnit != null)
            {
                //use existing specs (same spriteType)
                SpriteType spriteType = prevUnit.unitData.spriteAnimations.GetCurrentAnimation().spriteType;
                BaseInitializer.current.GetStage().InstantiateUnit_BySpriteType(spriteType);
                Unit newBackground = BaseInitializer.current.GetStage().units.GetLatestUnitByState<T>();

                SpriteAnimation animation = prevUnit.unitData.spriteAnimations.GetLastSpriteAnimation();
                Vector2 worldSize = animation.GetSpriteWorldSize(0);
                newBackground.transform.position = new Vector3(prevUnit.transform.position.x + worldSize.x, prevUnit.transform.position.y, prevUnit.transform.position.z);

                BaseInitializer.current.GetStage().units.AddUnit(newBackground);
            
                return newBackground;
            }
            else
            {
                return null;
            }
        }

        public void AddAdditionalAdjacentUnit<T>() where T: UnitState
        {
            Unit additionalBackground = InstantiateAdditionalBackgroundUnit<T>();
            GameObject camObj = _cameraScript.GetCamera().gameObject;
            
            if (typeof(T) == typeof(Swamp_Grass_DefaultState))
            {
                //negate existing camera offset
                float offsetX = camObj.transform.position.x * BaseInitializer.current.swampParallaxSO.Swamp_Grass_ParallaxPercentage;
                additionalBackground.gameObject.transform.localPosition -= new Vector3(offsetX, 0f, 0f);
                additionalBackground.iStateController.SetNewState(new Swamp_Grass_DefaultState(additionalBackground));
            }
            else if (typeof(T) == typeof(Swamp_River_DefaultState))
            {
                float offsetX = camObj.transform.position.x * BaseInitializer.current.swampParallaxSO.Swamp_River_ParallaxPercentage;
                additionalBackground.gameObject.transform.localPosition -= new Vector3(offsetX, 0f, 0f);
                additionalBackground.iStateController.SetNewState(new Swamp_River_DefaultState(additionalBackground));
            }
            else if (typeof(T) == typeof(Swamp_FrontTrees_DefaultState))
            {
                float offsetX = camObj.transform.position.x * BaseInitializer.current.swampParallaxSO.Swamp_FrontTrees_ParallaxPercentage;
                additionalBackground.gameObject.transform.localPosition -= new Vector3(offsetX, 0f, 0f);
                additionalBackground.iStateController.SetNewState(new Swamp_FrontTrees_DefaultState(additionalBackground));
            }
            else if (typeof(T) == typeof(Swamp_BackTrees_DefaultState))
            {
                float offsetX = camObj.transform.position.x * BaseInitializer.current.swampParallaxSO.Swamp_BackTrees_ParallaxPercentage;
                additionalBackground.gameObject.transform.localPosition -= new Vector3(offsetX, 0f, 0f);
                additionalBackground.iStateController.SetNewState(new Swamp_BackTrees_DefaultState(additionalBackground));
            }
        }
    }
}