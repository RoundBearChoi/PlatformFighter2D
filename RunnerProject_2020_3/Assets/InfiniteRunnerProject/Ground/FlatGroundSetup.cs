using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FlatGroundSetup : IBackgroundSetup
    {
        public void InstantiateBaseLayer()
        {
            Stage.currentStage.units.AddCreator(new FlatGround_Creator(Stage.currentStage.transform, 5, 10));
            Stage.currentStage.units.ProcessCreators();
        }

        public void AddAdditionalUnit<T>() where T : UnitState
        {
            Unit prevUnit = Stage.currentStage.units.GetLatestUnitByState<T>();

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