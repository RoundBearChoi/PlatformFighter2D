using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner : GameElement
    {
        private UserInput userInput = null;

        public StateController stateController = null;
        public CollisionDetector collisionDetector = null;

        public override void Init()
        {
            stateController = new StateController(new Runner_Idle());
            elementData = new GameElementData(this.transform);
        }

        public override void OnFixedUpdate()
        {
            stateController.TransitionToNextState(elementData);
            stateController.UpdateState(userInput, elementData);
        }

        public void SetUserInput(UserInput _userInput)
        {
            userInput = _userInput;
        }

        public void SetCollisionDetector(CollisionDetector collisionDetector)
        {
            collisionDetector = Instantiate(collisionDetector);
            collisionDetector.transform.parent = this.transform;
            collisionDetector.transform.position = Vector3.zero;
            collisionDetector.transform.localRotation = Quaternion.identity;
            collisionDetector.InitBoxCollider(new Vector2(3f, 5f));

            collisionDetector.transform.localPosition += new Vector3(0f, 2.5f, 0f);
        }
    }
}