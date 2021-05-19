using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultFixedUpdater : IUpdater
    {
        private StateController _stateController = null;

        public DefaultFixedUpdater(StateController stateController)
        {
            _stateController = stateController;
        }

        public void CustomUpdate()
        {
            _stateController.TransitionToNextState();
            _stateController.UpdateState();
        }
    }
}