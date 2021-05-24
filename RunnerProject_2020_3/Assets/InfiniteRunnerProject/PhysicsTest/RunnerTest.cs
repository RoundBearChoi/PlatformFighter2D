using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace RB.PhysicsTest
{
    public class RunnerTest : MonoBehaviour
    {
        [SerializeField]
        float JumpForce = 0f;

        private Keyboard _keyboard = null;
        private List<KeyControl> _listPresses = new List<KeyControl>();
        private Rigidbody2D _rigidbody = null;

        private void Start()
        {
            _keyboard = Keyboard.current;
            _rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_keyboard.spaceKey.wasPressedThisFrame)
            {
                _listPresses.Add(_keyboard.spaceKey);
            }
        }

        private void FixedUpdate()
        {
            if (_listPresses.Contains(_keyboard.spaceKey))
            {
                Debugger.Log("space pressed");
                _rigidbody.AddForce(Vector3.up * JumpForce);
            }

            _listPresses.Clear();
        }
    }
}