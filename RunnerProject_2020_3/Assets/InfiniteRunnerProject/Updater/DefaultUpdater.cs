using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultUpdater : IUpdater
    {
        private IStateController _IStateController = null;

        public DefaultUpdater(IStateController stateController)
        {
            _IStateController = stateController;
        }

        public void CustomFixedUpdate()
        {
            _IStateController.TransitionToNextState();
            _IStateController.OnFixedUpdate();
        }

        public void CustomLateUpdate()
        {
            _IStateController.OnLateUpdate();
        }
    }
}