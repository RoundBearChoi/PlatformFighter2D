using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner : Unit
    {
        private BottomCollisionChecker _bottomCollisionChecker = null;
        private FrontCollisionChecker _frontCollisionChecker = null;

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
                        Debugger.Log("ground collision");
                    }
                }
            }

            unitData.listCollisionData.Clear();
        }

        public override void OnCollision()
        {
            //Debugger.Log("runner collision");
            //
            //if (unitData.health > 0)
            //{
            //    unitData.health--;
            //    stateController.currentState.nextState = new Runner_Death_Up(unitData);
            //}
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            foreach(ContactPoint2D contactPoint in collision.contacts)
            {
                if (_bottomCollisionChecker.IsColliding(contactPoint))
                {
                    Debugger.Log("bottom collision");
                    unitData.listCollisionData.Add(new CollisionData(CollisionType.BOTTOM, collision.gameObject));
                }

                if (_frontCollisionChecker.IsColliding(contactPoint))
                {
                    Debugger.Log("front collision");
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
    }
}