using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : MonoBehaviour
    {
        public static GameInitializer current = null;

        public List<IStageTransition> listStageTransitions = new List<IStageTransition>();

        [Space(15)]
        public GameData gameDataSO = null;
        public SwampParallax swampParallaxSO;
        public Material white_GUIText_material;
        [SerializeField] private bool _useDebugLog;

        [Space(15)]
        [SerializeField]
        private List<BaseUnitCreationSpec> listCreationSpecsSO = new List<BaseUnitCreationSpec>();

        [Space(15)]
        public OverlapBoxCollisionData runner_overlapBoxCollsionDataSO;

        public SpecsGetter specsGetter = null;

        private void Start()
        {
            current = this;
            Debugger.Log("setting current GameInitializer instance");

            ResourceLoader.Init();

            //first stage
            IntroStageTransition introStageTransition = new IntroStageTransition(this);
            Stage.currentStage = introStageTransition.MakeTransition();

            specsGetter = new SpecsGetter(listCreationSpecsSO);
        }

        private void Update()
        {
            Debugger.useLog = _useDebugLog;

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

        public void RunCoroutine(IEnumerator enumerator)
        {
            StartCoroutine(enumerator);
        }
    }
}