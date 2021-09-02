using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FlatGroundSetup : IBackgroundSetup
    {
        public void InstantiateBaseLayer()
        {
            BaseInitializer.current.GetStage().units.AddCreator(new FlatGround_Creator(BaseInitializer.current.GetStage().transform, 5, 10));
            BaseInitializer.current.GetStage().units.ProcessCreators();
        }

        public void AddAdditionalAdjacentUnit<T>() where T : UnitState
        {
            Unit prevUnit = BaseInitializer.current.GetStage().units.GetLatestUnitByState<T>();

            if (prevUnit != null)
            {
                Vector3 topRight = prevUnit.unitData.compositeCollider2D.bounds.center + (prevUnit.unitData.compositeCollider2D.bounds.size * 0.5f);

                InstantiateBaseLayer();
                Unit newGround = BaseInitializer.current.GetStage().units.GetUnit<Ground>();

                newGround.transform.position = new Vector3(topRight.x, prevUnit.transform.position.y, prevUnit.transform.position.z);

                Debugger.Log("latest ground position: " + newGround.transform.position);
            }
        }
    }
}