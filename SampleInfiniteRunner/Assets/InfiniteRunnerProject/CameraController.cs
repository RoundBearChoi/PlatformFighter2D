using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController : MonoBehaviour
    {
        private Runner runner = null;
        private Camera mainCam = null;

        public void SetRunner(Runner _runner)
        {
            runner = _runner;
            mainCam = FindObjectOfType<Camera>();
        }

        public void OnFixedUpdate()
        {
            mainCam.transform.position = new Vector3(0f, 0f, -5f) + runner.transform.position;
        }
    }
}