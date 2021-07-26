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
            _updater = new NPCSetupUpdater(ownerStage, this);
        }

        public override void OnFixedUpdate()
        {

        }

        public override void OnUpdate()
        {

        }

        public override void OnLateUpdate()
        {

        }
    }
}