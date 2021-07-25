using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseNPCSetup
    {
        private BaseStage _stage = null;
        private BaseUpdater _updater = null;

        public BaseNPCSetup(BaseStage ownerStage)
        {
            _stage = ownerStage;
        }

        public abstract void OnFixedUpdate();
    }
}