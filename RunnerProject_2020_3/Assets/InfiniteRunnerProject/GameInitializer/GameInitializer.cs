using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : MonoBehaviour
    {
        public List<IStageTransition> listStageTransitions = new List<IStageTransition>();

        [Space(15)]
        [SerializeField] private GameData gameDataSO = null;
        [SerializeField] private SwampParallax swampParallaxSO = null;

        [Space(15)]
        [SerializeField] private List<BaseUnitCreationSpec> listCreationSpecsSO = new List<BaseUnitCreationSpec>();

        private void Start()
        {
            StaticRefs.gameData = gameDataSO;
            StaticRefs.swampParallaxData = swampParallaxSO;
            StaticRefs.listCreationSpecs = listCreationSpecsSO;

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