using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class PlacerUpdater : IUpdater
    {
        private IStateController _IStateController = null;
        private Unit _runner = null;
        private float _previousX = 0f;
        private float _distance = 0f;

        public PlacerUpdater(IStateController stateController, Unit runner)
        {
            _IStateController = stateController;
            _runner = runner;
        }

        public void CustomFixedUpdate()
        {
            if (_runner.transform.position.x > _previousX)
            {
                _distance += _runner.transform.position.x - _previousX;
                _previousX = _runner.transform.position.x;
            }
            
            if (_distance > 10f)
            {
                _distance = 0f;
                _IStateController.TransitionToNextState();
                _IStateController.OnFixedUpdate();
            }
        }

        public void CustomLateUpdate()
        {

        }
    }
}