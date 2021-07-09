using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultUpdater : BaseUpdater
    {
        public void SetOwnerUnit(Unit unit)
        {
            _unit = unit;
        }

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