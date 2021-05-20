using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : MonoBehaviour
    {
        Stage _currentStage = null;
        public IStageTransition stageTransition = null;

        private void Start()
        {
            ResourceLoader.Init();

            IntroStageTransition introStageTransition = new IntroStageTransition(this);

            _currentStage = introStageTransition.MakeTransition();
        }

        private void Update()
        {
            if (_currentStage != null)
            {
                _currentStage.OnUpdate();

                if (stageTransition != null)
                {
                    Destroy(_currentStage.gameObject);
                    _currentStage = stageTransition.MakeTransition();
                    stageTransition = null;
                }
            }
        }

        private void FixedUpdate()
        {
            if (_currentStage != null)
            {
                _currentStage.OnFixedUpdate();
            }
        }
    }
}