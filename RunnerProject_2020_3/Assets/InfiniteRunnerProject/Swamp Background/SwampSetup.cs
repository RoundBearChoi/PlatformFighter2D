using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SwampSetup
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
                SpriteAnimation animation = prevUnit.unitData.spriteAnimations.GetLastSpriteAnimation();
                Vector2 worldSize = animation.GetSpriteWorldSize(0);
                Debug.DrawLine(new Vector3(10f, 50f), worldSize, Color.red, 3f);

                SpriteAnimationSpec spriteSpec = prevUnit.iStateController.GetCurrentState().GetSpriteAnimationSpec();
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

        public void AddAdditionalSwamp_Grass()
        {
            Unit newGrass = InstantiateAdditionalBackgroundUnit<Swamp_Grass_DefaultState>();
            newGrass.iStateController.SetNewState(new Swamp_Grass_DefaultState(newGrass));
        }

        public void AddAdditionalSwamp_River()
        {
            Unit newRiver = InstantiateAdditionalBackgroundUnit<Swamp_River_DefaultState>();
            newRiver.iStateController.SetNewState(new Swamp_River_DefaultState(newRiver));
        }

        public void AddAdditionalSwamp_FrontTrees()
        {
            Unit newRiver = InstantiateAdditionalBackgroundUnit<Swamp_FrontTrees_DefaultState>();
            newRiver.iStateController.SetNewState(new Swamp_FrontTrees_DefaultState(newRiver));
        }

        public void AddAdditionalSwamp_BackTrees()
        {
            Unit newRiver = InstantiateAdditionalBackgroundUnit<Swamp_BackTrees_DefaultState>();
            newRiver.iStateController.SetNewState(new Swamp_BackTrees_DefaultState(newRiver));
        }
    }
}