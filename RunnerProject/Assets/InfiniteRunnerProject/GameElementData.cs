using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameElementData
    {
        public GameElementData(Transform ownerTransform)
        {
            elementTransform = ownerTransform;
        }

        public float horizontalVelocity = 0f;
        public float verticalVelocity = 0f;
        public Transform elementTransform = null;
    }
}