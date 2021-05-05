using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Obstacle_Idle : State
    {
        public override void OnEnter(GameElementData elementData)
        {
            elementData.elementTransform.position = new Vector3(15f, 0f, 0f);
        }

        public override void Update(GameElementData elementData)
        {

        }
    }
}