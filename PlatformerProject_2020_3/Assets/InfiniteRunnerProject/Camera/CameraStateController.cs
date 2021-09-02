using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraStateController : IStateController<CameraState>
    {
        public CameraState currentCameraState = new Camera_EmptyState();

        public CameraState GetCurrentState()
        {
            return currentCameraState;
        }

        public void OnUpdate()
        {
            currentCameraState.OnUpdate();
        }

        public void OnFixedUpdate()
        {
            currentCameraState.OnFixedUpdate();
        }

        public void OnLateUpdate()
        {
            currentCameraState.OnLateUpdate();
        }

        public void SetNewState(CameraState newCameraState)
        {
            currentCameraState = newCameraState;
        }

        public void TransitionToNextState()
        {

        }
    }
}