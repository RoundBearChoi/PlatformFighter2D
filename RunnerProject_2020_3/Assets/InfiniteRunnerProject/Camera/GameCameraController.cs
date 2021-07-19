using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameCameraController : Unit
    {
        public static GameCameraController current = null;

        public uint mTotalShakeFrames = 0;
        public Vector3 mTargetPosition = Vector3.zero;
        public Camera gameCam = null;

        public GameCameraController()
        {
            messageHandler = new CameraMessageHandler(this);
        }

        public override void OnFixedUpdate()
        {
            iStateController.TransitionToNextState();
            iStateController.OnFixedUpdate();

            if (mTotalShakeFrames > 0)
            {
                mTotalShakeFrames--;
                Vector3 shakeOffset = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.075f, 0.075f), 0f);
                gameCam.transform.position = mTargetPosition + shakeOffset;
            }
            else
            {
                gameCam.transform.position = mTargetPosition;
            }
        }
    }
}