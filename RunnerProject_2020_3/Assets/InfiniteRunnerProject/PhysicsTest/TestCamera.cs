using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.PhysicsTest
{
    public class TestCamera : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _offset = new Vector3();

        private RunnerTest _runner = null;

        private void Start()
        {
            _runner = GameObject.FindObjectOfType<RunnerTest>();
        }

        private void FixedUpdate()
        {
            this.transform.position = _runner.transform.position + _offset;
        }
    }
}