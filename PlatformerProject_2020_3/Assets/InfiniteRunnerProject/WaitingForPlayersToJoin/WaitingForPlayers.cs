using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class WaitingForPlayers : UIElement
    {
        public override void OnFixedUpdate()
        {
            UpdateSpriteAnimation();
        }
    }
}