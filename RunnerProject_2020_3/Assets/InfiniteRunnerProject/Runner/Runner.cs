using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner : Unit
    {
        private BottomCollisionChecker _bottomCollisionChecker = null;

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
        }

        public override void OnCollision()
        {
            Debugger.Log("runner collision");

            if (unitData.health > 0)
            {
                unitData.health--;
                stateController.currentState.nextState = new Runner_Death_Up(unitData);
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            Ground ground = collision.gameObject.GetComponent<Ground>();
        
            foreach(ContactPoint2D contactPoint in collision.contacts)
            {
                if (_bottomCollisionChecker.IsColliding(contactPoint))
                {
                    Debug.Log("bottom collision");
                }
            }

            if (ground != null)
            {
                Debugger.Log("runner hit ground");
            }
        }

        public override void InitCollisionCheckers()
        {
            _bottomCollisionChecker = new BottomCollisionChecker(this.gameObject.GetComponent<BoxCollider2D>());
        }
    }
}