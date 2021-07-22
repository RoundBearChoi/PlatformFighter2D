using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RandomFlatGroundSetup : IBackgroundSetup
    {
        public void InstantiateBaseLayer()
        {
            Stage.currentStage.units.AddCreator(new FlatGround_Creator(Stage.currentStage.transform));
            Stage.currentStage.units.ProcessCreators();
        }

        public void AddAdditionalUnit<T>() where T : UnitState
        {
            Unit prevUnit = Stage.currentStage.units.GetLatestUnitByState<T>();
            //Unit prevUnit = Stage.currentStage.units.GetUnit<Ground>();

            if (prevUnit != null)
            {
                Vector3 topRight = prevUnit.unitData.compositeCollider2D.bounds.center + (prevUnit.unitData.compositeCollider2D.bounds.size * 0.5f);

                InstantiateBaseLayer();
                Unit newGround = Stage.currentStage.units.GetUnit<Ground>();
                newGround.transform.position = new Vector3(topRight.x, prevUnit.transform.position.y, prevUnit.transform.position.z);
                Debugger.Log("latest ground position: " + newGround.transform.position);
            }
        }
    }
}