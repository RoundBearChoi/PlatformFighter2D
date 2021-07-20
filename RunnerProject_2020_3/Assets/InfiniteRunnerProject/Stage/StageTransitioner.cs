using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StageTransitioner
    {
        private List<IStageTransition> _listStageTransitions = new List<IStageTransition>();

        public void AddTransition(IStageTransition transition)
        {
            _listStageTransitions.Add(transition);
        }

        public void Update()
        {
            foreach (IStageTransition transition in _listStageTransitions)
            {
                GameObject.Destroy(Stage.currentStage.gameObject);
                Stage.currentStage = transition.MakeTransition();
            }

            _listStageTransitions.Clear();
        }
    }
}