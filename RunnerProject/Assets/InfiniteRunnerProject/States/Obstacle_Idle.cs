using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Obstacle_Idle : State
    {
        public Obstacle_Idle(GameElementData _elementData)
        {
            elementData = _elementData;
            //userInput = _userInput;
        }

        public override void OnEnter()
        {
            elementData.elementTransform.position = new Vector3(15f, 0f, 0f);
        }

        public override void Update()
        {

        }
    }
}