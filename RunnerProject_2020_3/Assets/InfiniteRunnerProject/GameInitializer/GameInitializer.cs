using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : MonoBehaviour
    {
        public List<IStageTransition> listStageTransitions = new List<IStageTransition>();

        [SerializeField]
        private GameData gameDataScriptableObj = null;

        [SerializeField]
        private RunnerMovementSpriteData runnerMovementSpriteDataScriptableObj = null;

        [SerializeField]
        private RunnerAttackSpriteData runnerAttackSpriteDataScriptableObj = null;

        [SerializeField]
        private MovementDustSpriteData vfxSpriteDataScriptableObj = null;

        [SerializeField]
        private SwampSpriteData swampSpriteDataScriptableObj = null;

        [SerializeField]
        private GolemSpriteData golemSpriteDataScriptableObj = null;

        private void Start()
        {
            StaticRefs.gameData = gameDataScriptableObj;
            StaticRefs.runnerMovementSpriteData = runnerMovementSpriteDataScriptableObj;
            StaticRefs.runnerAttackSpriteData = runnerAttackSpriteDataScriptableObj;
            StaticRefs.movementDustSpriteData = vfxSpriteDataScriptableObj;
            StaticRefs.swampSpriteData = swampSpriteDataScriptableObj;
            StaticRefs.golemSpriteData = golemSpriteDataScriptableObj;

            Debugger.Log("setting current GameInitializer instance");

            ResourceLoader.Init();

            //first stage
            IntroStageTransition introStageTransition = new IntroStageTransition(this);
            Stage.currentStage = introStageTransition.MakeTransition();
        }

        private void Update()
        {
            Stage.currentStage.OnUpdate();

            foreach(IStageTransition transition in listStageTransitions)
            {
                Destroy(Stage.currentStage.gameObject);
                Stage.currentStage = transition.MakeTransition();
            }

            listStageTransitions.Clear();
        }

        private void FixedUpdate()
        {
            Stage.currentStage.OnFixedUpdate();
        }

        private void LateUpdate()
        {
            Stage.currentStage.OnLateUpdate();
        }
    }
}