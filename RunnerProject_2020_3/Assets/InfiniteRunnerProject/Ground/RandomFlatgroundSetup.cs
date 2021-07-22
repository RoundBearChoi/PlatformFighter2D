using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RandomFlatgroundSetup : IBackgroundSetup
    {
        public void InstantiateBaseLayer()
        {
            Stage.currentStage.units.AddCreator(new FlatGround_Creator(Stage.currentStage.transform));
            Stage.currentStage.units.ProcessCreators();
        }

        public Unit InstantiateAdditionalBackgroundUnit<T>()
        {
            return null;
        }

        public void AddAdditionalBackground<T>() where T : UnitState
        {

        }
    }
}