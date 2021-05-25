using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace RB.PhysicsTest
{
    public enum CollisionType
    {
        NONE,
        BOTTOM,
        FRONT,
    }

    public class RunnerTest : MonoBehaviour
    {
        [SerializeField]
        float JumpForce = 0f;

        [SerializeField]
        private float TargetGroundVelocity = 0f;

        [SerializeField]
        private GroundTest currentGround = null;

        [SerializeField]
        private float velocitySqMag = 0f;

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
                _rigidbody.velocity = new Vector2(TargetGroundVelocity, JumpForce);
                currentGround = null;
            }

            _listPresses.Clear();
            velocitySqMag = _rigidbody.velocity.sqrMagnitude;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GroundTest ground = collision.gameObject.GetComponent<GroundTest>();
            EnemyTest enemy = collision.gameObject.GetComponent<EnemyTest>();
            
            if (ground != null)
            {
                List<CollisionType> listCollisions = GetCollisionTypes(collision);

                if (listCollisions.Contains(CollisionType.BOTTOM))
                {
                    if (currentGround != ground)
                    {
                        currentGround = ground;
                        _rigidbody.velocity = new Vector2(TargetGroundVelocity, _rigidbody.velocity.y);
                        Debug.Log("resetting velocity on new ground..");
                    }
                }
            }

            if (enemy != null)
            {
                List<CollisionType> listCollisions = GetCollisionTypes(collision);

                if (listCollisions.Contains(CollisionType.BOTTOM) && !listCollisions.Contains(CollisionType.FRONT))
                {
                    Debug.Log("enemy bottom collision!");
                }
                else if (listCollisions.Contains(CollisionType.FRONT))
                {
                    Debug.Log("enemy front collision!");
                }
            }
        }

        private List<CollisionType> GetCollisionTypes(Collision2D collision)
        {
            List<CollisionType> listCollisionTypes = new List<CollisionType>();

            foreach (ContactPoint2D p in collision.contacts)
            {
                Vector2 bottomLeft = new Vector3(
                    _collider2D.bounds.center.x - _collider2D.bounds.extents.x - 3f,
                    _collider2D.bounds.center.y - _collider2D.bounds.extents.y);

                Vector2 topRight = new Vector3(
                    _collider2D.bounds.center.x + _collider2D.bounds.extents.x,
                    _collider2D.bounds.center.y + _collider2D.bounds.extents.y + 3f);

                Vector2 right = p.point - bottomLeft;
                right.Normalize();

                Vector2 down = p.point - topRight;
                down.Normalize();

                float bottomDot = Vector2.Dot(right, Vector2.right);
                float frontDot = Vector2.Dot(down, Vector2.down);

                if (bottomDot >= 0.999f && bottomDot <= 1f)
                {
                    Debug.Log("bottom collision");
                    Debug.DrawLine(bottomLeft, p.point, Color.green, 1f);

                    listCollisionTypes.Add(CollisionType.BOTTOM);
                }

                if (frontDot >= 0.999f && frontDot <= 1f)
                {
                    if (p.normal.y <= 0f)
                    {
                        Debug.Log("front collision");
                        Debug.DrawLine(topRight, p.point, Color.green, 1f);
                        listCollisionTypes.Add(CollisionType.FRONT);
                    }
                }
            }

            return listCollisionTypes;
        }
    }
}