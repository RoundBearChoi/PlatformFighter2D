using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ObstaclePlacer : Unit
    {
        public override void OnFixedUpdate()
        {
            if (unitUpdater != null)
            {
                unitUpdater.CustomUpdate();
            }
        }
    }
}