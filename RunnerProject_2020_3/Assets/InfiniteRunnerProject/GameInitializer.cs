using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : MonoBehaviour
    {
        Stage _currentStage = null;
        public List<IStageTransition> listStageTransitions = new List<IStageTransition>();

        private void Start()
        {
            ResourceLoader.Init();
            IntroStageTransition introStageTransition = new IntroStageTransition(this);
            _currentStage = introStageTransition.MakeTransition();
        }

        private void Update()
        {
            _currentStage.OnUpdate();

            foreach(IStageTransition transition in listStageTransitions)
            {
                Destroy(_currentStage.gameObject);
                _currentStage = transition.MakeTransition();
            }

            listStageTransitions.Clear();
        }

        private void FixedUpdate()
        {
            _currentStage.OnFixedUpdate();
        }

        private void LateUpdate()
        {
            _currentStage.OnLateUpdate();
        }
    }
}