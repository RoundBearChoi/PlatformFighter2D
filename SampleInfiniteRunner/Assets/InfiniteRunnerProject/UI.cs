using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class UI : MonoBehaviour
    {
        private FixedUpdateCounter frameCounter = null;

        public Text text = null;

        public void SetFrameCounter(FixedUpdateCounter _frameCounter)
        {
            frameCounter = _frameCounter;
        }

        public void OnUpdate()
        {
            text.text = "FixedUpdate count: " + frameCounter.GetCount();
        }
    }
}

