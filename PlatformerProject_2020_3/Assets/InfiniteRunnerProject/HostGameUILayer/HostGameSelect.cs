using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class HostGameSelect : UISelection
    {
        public override void OnFixedUpdate()
        {

        }

        public override void OnUpdate()
        {
            UpdateSelection();
        }

        public override void OnLateUpdate()
        {
            UpdateSelectionArrowPosition();
        }
    }
}