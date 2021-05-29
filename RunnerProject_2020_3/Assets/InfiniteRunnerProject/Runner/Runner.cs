using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner : Unit
    {
        private UserInput _userInput = null;
        private ICollisionSideChecker _collisionChecker = null;

        public override void OnFixedUpdate()
        {
            unitUpdater.CustomUpdate();

            foreach (SpriteAnimation ani in listSpriteAnimations)
            {
                ani.OnFixedUpdate();
            }

            foreach(CollisionData data in unitData.listCollisionData)
            {
                //temp code
                Unit unit = data.collidingObject.GetComponent<Unit>();

                if (unit != null)
                {
                    if (data.collisionType == CollisionType.BOTTOM)
                    {
                        if (!unit.listDangerousSides.Contains(CollisionType.TOP))
                        {
                            Destroy(unit.gameObject);
                            unitData.rigidBody2D.velocity = StaticRefs.gameData.Runner_JumpUp_StartForce;
                        }
                    }

                    foreach(CollisionType danger in unit.listDangerousSides)
                    {
                        if (danger == CollisionType.LEFT && data.collisionType == CollisionType.RIGHT)
                        {
                            Debugger.Log("take damage!");
                            unitData.listNextStates.Add(new Runner_Death_Up(unitData));
                        }
                    }
                }
                ///

                Ground ground = data.collidingObject.GetComponent<Ground>();

                if (ground != null)
                {
                    if (data.collisionType == CollisionType.BOTTOM)
                    {
                        Debugger.Log("bottom collision detected");

                        if (ground != unitData.currentGround)
                        {
                            Debugger.Log("new ground collision");
                            unitData.currentGround = ground;
                            unitData.listNextStates.Add(new Runner_NormalRun(unitData, _userInput));
                            break;
                        }
                    }
                }
            }

            unitData.listCollisionData.Clear();
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            foreach(ContactPoint2D contactPoint in collision.contacts)
            {
                CollisionType collisionType = _collisionChecker.GetCollisionType(contactPoint);
                CollisionData collisionData = new CollisionData(collisionType, collision.gameObject);
                unitData.listCollisionData.Add(collisionData);
            }
        }

        public override void InitCollisionChecker()
        {
            BoxCollider2D collider = this.gameObject.GetComponent<BoxCollider2D>();
            _collisionChecker = new CollisionChecker(collider);
        }

        public override void SetUserInput(UserInput userInput)
        {
            _userInput = userInput;
        }
    }
}