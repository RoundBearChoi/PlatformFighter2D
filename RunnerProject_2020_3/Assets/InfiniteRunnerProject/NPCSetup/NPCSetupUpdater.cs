using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class NPCSetupUpdater : BaseUpdater
    {
        private BaseStage _stage = null;
        BaseNPCSetup _setup = null;
        private Unit _runner = null;

        public NPCSetupUpdater(BaseStage stage, BaseNPCSetup setup)
        {
            _stage = stage;
            _setup = setup;
            _runner = stage.units.GetUnit<Runner>();
        }

        public override void CustomFixedUpdate()
        {
            _setup.OnFixedUpdate();
        }

        public override void CustomUpdate()
        {
            _setup.OnUpdate();
        }

        public override void CustomLateUpdate()
        {
            _setup.OnLateUpdate();
        }
    }
}