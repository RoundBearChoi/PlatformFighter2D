using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerStageNPCSetup : BaseNPCSetup
    {
        public RunnerStageNPCSetup(BaseStage ownerStage)
        {
            _stage = ownerStage;
            _updater = new NPCSetupUpdater(ownerStage);
        }

        public override void OnFixedUpdate()
        {
            _updater.CustomFixedUpdate();
        }

        public override void OnUpdate()
        {
            _updater.CustomUpdate();
        }

        public override void OnLateUpdate()
        {
            _updater.CustomLateUpdate();
        }
    }
}