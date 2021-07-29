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

        private float _runnerPreviousPosX = 0f;
        private float _runDistance = 0f;
        private float _runCumulativeDistance = 0f;

        public NPCSetupUpdater(BaseStage stage, BaseNPCSetup setup)
        {
            _stage = stage;
            _setup = setup;
            _runner = stage.units.GetUnit<PlayerUnit>();
        }

        public override void CustomFixedUpdate()
        {
            _runDistance = _runner.transform.position.x - _runnerPreviousPosX;
            _runCumulativeDistance += _runDistance;
            
            _runnerPreviousPosX = _runner.transform.position.x;

            if (_runCumulativeDistance >= 20f)
            {
                _setup.InstantiateNPC();
                _runCumulativeDistance = 0f;
            }
        }

        public override void CustomUpdate()
        {

        }

        public override void CustomLateUpdate()
        {

        }
    }
}