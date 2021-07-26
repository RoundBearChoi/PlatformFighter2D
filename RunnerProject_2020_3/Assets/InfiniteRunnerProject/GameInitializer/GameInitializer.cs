using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : BaseInitializer
    {
        [Space(15)]
        public GameData gameDataSO = null;
        public SwampParallax swampParallaxSO;
        [SerializeField] private bool _useDebugLog;

        [Space(15)]
        [SerializeField]
        private List<BaseUnitCreationSpec> listCreationSpecsSO = new List<BaseUnitCreationSpec>();

        [Space(15)]
        public OverlapBoxCollisionData runner_AttackA_OverlapBoxSO;
        public OverlapBoxCollisionData runner_AttackB_OverlapBoxSO;
        public OverlapBoxCollisionData golem_Attack_OverlapBoxSO;

        public StageTransitioner stageTransitioner = null;

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

        public override OverlapBoxCollisionData GetHitBoxData(HitBoxDataType boxType)
        {
            if (boxType == HitBoxDataType.RUNNER_ATTACK_A)
            {
                return runner_AttackA_OverlapBoxSO;
            }
            else if (boxType == HitBoxDataType.RUNNER_ATTACK_B)
            {
                return runner_AttackB_OverlapBoxSO;
            }

            else if (boxType == HitBoxDataType.GOLEM_ATTACK_A)
            {
                return golem_Attack_OverlapBoxSO;
            }

            return null;
        }

        public override SwampParallax GetParallaxData(ParallaxDataType parallaxType)
        {
            if (parallaxType == ParallaxDataType.SWAMP)
            {
                return swampParallaxSO;
            }

            return null;
        }

        public override GameData GetGameData(GameDataType gameDataType)
        {
            if (gameDataType == GameDataType.RUNNER)
            {
                return gameDataSO;
            }

            return null;
        }
    }
}