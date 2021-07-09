using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultUpdater : BaseUpdater
    {
        public override void CustomFixedUpdate()
        {
            _unit.iStateController.TransitionToNextState();
            _unit.iStateController.OnFixedUpdate();
        }

        public override void CustomLateUpdate()
        {
            _unit.iStateController.OnLateUpdate();
        }
    }
}