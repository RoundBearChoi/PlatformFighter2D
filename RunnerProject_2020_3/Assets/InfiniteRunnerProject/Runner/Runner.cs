using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner : Unit
    {
        private BottomCollisionChecker _bottomCollisionChecker = null;
        private FrontCollisionChecker _frontCollisionChecker = null;
        private UserInput _userInput = null;

        public override void OnFixedUpdate()
        {
            if (unitUpdater != null)
            {
                unitUpdater.CustomUpdate();
            }

            foreach(SpriteAnimation ani in listSpriteAnimations)
            {
                ani.OnFixedUpdate();
            }

            foreach(CollisionData data in unitData.listCollisionData)
            {
                if (data.collisionType == CollisionType.BOTTOM)
                {
                    Debugger.Log("bottom collision detected");

                    Ground ground = data.collidingObject.GetComponent<Ground>();

                    if (ground != null)
                    {
                        if (ground != unitData.currentGround)
                        {
                            Debugger.Log("new ground collision");
                            unitData.currentGround = ground;
                            unitData.listNextStates.Add(new Runner_NormalRun(unitData, _userInput));
                            break;
                        }
                    }
                }

                if (data.collisionType == CollisionType.FRONT)
                {
                    Debugger.Log("front collision detected");
                }
            }

            unitData.listCollisionData.Clear();
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            foreach(ContactPoint2D contactPoint in collision.contacts)
            {
                if (_bottomCollisionChecker.IsColliding(contactPoint))
                {
                    unitData.listCollisionData.Add(new CollisionData(CollisionType.BOTTOM, collision.gameObject));
                }

                if (_frontCollisionChecker.IsColliding(contactPoint))
                {
                    unitData.listCollisionData.Add(new CollisionData(CollisionType.FRONT, collision.gameObject));
                }
            }
        }

        public override void InitCollisionCheckers()
        {
            BoxCollider2D collider = this.gameObject.GetComponent<BoxCollider2D>();
            _bottomCollisionChecker = new BottomCollisionChecker(collider);
            _frontCollisionChecker = new FrontCollisionChecker(collider);
        }

        public override void SetUserInput(UserInput userInput)
        {
            _userInput = userInput;
        }
    }
}