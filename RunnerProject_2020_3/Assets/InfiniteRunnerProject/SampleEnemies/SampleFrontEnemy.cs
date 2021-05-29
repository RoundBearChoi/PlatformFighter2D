using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SampleFrontEnemy : Unit
    {
        private void Start()
        {
            listDangerousSides.Clear();
            listDangerousSides.Add(CollisionType.FRONT);
        }
    }
}