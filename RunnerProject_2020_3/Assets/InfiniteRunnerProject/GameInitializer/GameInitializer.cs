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
        public OverlapBoxCollisionData runner_AttackA_OverlapBoxSO;
        public OverlapBoxCollisionData runner_AttackB_OverlapBoxSO;
        public OverlapBoxCollisionData golem_Attack_OverlapBoxSO;

        public SpecsGetter specsGetter = null;
        public StageTransitioner stageTransitioner = null;


        private Stage _stage = null;

        private void Start()
        {
            current = this;
            Debugger.Log("setting current GameInitializer instance");

            ResourceLoader.Init();

            //first stage
            IStageTransition intro = new IntroStageTransition(this);
            _stage = intro.MakeTransition();
            _stage.Init();
            
            specsGetter = new SpecsGetter(listCreationSpecsSO);
            stageTransitioner = new StageTransitioner();
        }

        public Stage STAGE
        {
            get
            {
                return _stage;
            }
        }

        public void SetStage(Stage stage)
        {
            _stage = stage;
        }

        private void Update()
        {
            Debugger.useLog = _useDebugLog;

            stageTransitioner.Update();
            _stage.OnUpdate();
        }

        private void FixedUpdate()
        {
            _stage.OnFixedUpdate();
        }

        private void LateUpdate()
        {
            _stage.OnLateUpdate();
        }

        public void RunCoroutine(IEnumerator enumerator)
        {
            StartCoroutine(enumerator);
        }
    }
}