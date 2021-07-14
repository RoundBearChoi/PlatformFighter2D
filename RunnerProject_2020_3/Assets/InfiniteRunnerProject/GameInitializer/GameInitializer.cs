using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : MonoBehaviour
    {
        public static GameInitializer current = null;

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
        public StageTransitioner stageTransitioner = null;

        private void Start()
        {
            current = this;
            Debugger.Log("setting current GameInitializer instance");

            ResourceLoader.Init();

            //first stage
            IntroStageTransition introStageTransition = new IntroStageTransition(this);
            Stage.currentStage = introStageTransition.MakeTransition();

            specsGetter = new SpecsGetter(listCreationSpecsSO);
            stageTransitioner = new StageTransitioner();
        }

        private void Update()
        {
            Debugger.useLog = _useDebugLog;

            stageTransitioner.Update();
            Stage.currentStage.OnUpdate();
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