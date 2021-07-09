using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : MonoBehaviour
    {
        public List<IStageTransition> listStageTransitions = new List<IStageTransition>();

        //needs cleanup
        [SerializeField] private GameData gameDataScriptableObj = null;
        //[SerializeField] private RunnerMovementSpriteData runnerMovementSpriteDataScriptableObj = null;
        //[SerializeField] private RunnerAttackSpriteData runnerAttackSpriteDataScriptableObj = null;
        [SerializeField] private MovementDustSpriteData vfxSpriteDataScriptableObj = null;
        [SerializeField] private SwampParallax swampSpriteDataScriptableObj = null;
        [SerializeField] private GolemSpriteData golemSpriteDataScriptableObj = null;

        //a list later maybe
        [SerializeField] private UnitCreationSpec runnerCreationSpecScriptableObj = null;
        [SerializeField] private UnitCreationSpec golemCreationSpecScriptableObj = null;
        [SerializeField] private UnitCreationSpec swamp_grass_creationSpecSO = null;
        [SerializeField] private UnitCreationSpec swamp_river_creationSpecSO = null;
        [SerializeField] private UnitCreationSpec swamp_frontTrees_creationSpecSO = null;
        [SerializeField] private UnitCreationSpec swamp_backTrees_creationSpecSO = null;

        private void Start()
        {
            StaticRefs.gameData = gameDataScriptableObj;
            //StaticRefs.runnerMovementSpriteData = runnerMovementSpriteDataScriptableObj;
            //StaticRefs.runnerAttackSpriteData = runnerAttackSpriteDataScriptableObj;
            StaticRefs.movementDustSpriteData = vfxSpriteDataScriptableObj;
            StaticRefs.swampSpriteData = swampSpriteDataScriptableObj;
            StaticRefs.golemSpriteData = golemSpriteDataScriptableObj;

            StaticRefs.runnerCreationSpec = runnerCreationSpecScriptableObj;
            StaticRefs.golemCreationSpec = golemCreationSpecScriptableObj;
            StaticRefs.swamp_Grass_CreationSpec = swamp_grass_creationSpecSO;
            StaticRefs.swamp_River_CreationSpec = swamp_river_creationSpecSO;
            StaticRefs.swamp_FrontTrees_CreationSpec = swamp_frontTrees_creationSpecSO;
            StaticRefs.swamp_BackTrees_CreationSpec = swamp_backTrees_creationSpecSO;

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