using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp : Unit
    {
        public Vector2 basePosition = Vector2.zero;

        public override void OnUpdate()
        {
            unitUpdater.CustomUpdate();
        }

        public override void OnFixedUpdate()
        {
            unitUpdater.CustomFixedUpdate();
        }
    }
}