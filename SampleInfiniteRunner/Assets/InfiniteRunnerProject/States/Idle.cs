using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Idle : State
    {
        public Idle()
        {
            Debugger.Log("new state: Idle");
        }

        public override void OnFixedUpdate()
        {

        }
    }
}