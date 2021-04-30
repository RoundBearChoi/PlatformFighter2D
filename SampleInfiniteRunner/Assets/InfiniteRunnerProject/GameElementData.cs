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

        public float UpVelocity = 0f;
        public Transform elementTransform = null;
    }
}