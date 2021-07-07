using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : MonoBehaviour
    {
        public static GameInitializer instance = null;

        Stage _currentStage = null;
        public List<IStageTransition> listStageTransitions = new List<IStageTransition>();

        [SerializeField]
        private GameData gameDataScriptableObj = null;

        [SerializeField]
        private RunnerSpriteData runnerSpriteDataScriptableObj = null;

        [SerializeField]
        private MovementDustSpriteData vfxSpriteDataScriptableObj = null;

        private void Start()
        {
            StaticRefs.gameData = gameDataScriptableObj;
            StaticRefs.runnerSpriteData = runnerSpriteDataScriptableObj;
            StaticRefs.vfxSpriteData = vfxSpriteDataScriptableObj;

            Debugger.Log("setting current GameInitializer instance");
            instance = this;

            ResourceLoader.Init();

            //first stage
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