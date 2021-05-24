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
        private BoxCollider2D _collider2D = null;

        private void Start()
        {
            _keyboard = Keyboard.current;
            _rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
            _collider2D = this.gameObject.GetComponent<BoxCollider2D>();
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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GroundTest ground = collision.gameObject.GetComponent<GroundTest>();

            if (ground != null)
            {
                foreach (ContactPoint2D p in collision.contacts)
                {
                    Vector3 relativePos = new Vector3(p.point.x, p.point.y, 0f) - _collider2D.bounds.center;
                    Debug.DrawLine(_collider2D.bounds.center, _collider2D.bounds.center + relativePos, Color.red, 0.5f);

                    float upDot = Vector3.Dot(relativePos, Vector3.up);
                    float leftDot = Vector3.Dot(relativePos, Vector3.left);
                    float rightDot = Vector3.Dot(relativePos, Vector3.right);
                    float bottomDot = Vector3.Dot(relativePos, Vector3.down);

                    Debugger.Log("upDot: " + upDot);
                    Debugger.Log("leftDot: " + leftDot);
                    Debugger.Log("rightDot: " + rightDot);
                    Debugger.Log("bottomDot: " + bottomDot);

                    if (bottomDot > 0f)
                    {
                        if (bottomDot > upDot &&
                            bottomDot > leftDot &&
                            bottomDot > rightDot)
                        {
                            Debugger.Log("contact point is bottom");
                        }
                    }
                }
            }
        }
    }
}