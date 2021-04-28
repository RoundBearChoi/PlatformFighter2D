using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FrameCounter
    {
        int frameCount = 0;
        float fElapsedTime = 0f;

        public void OnFixedUpdate()
        {
            frameCount++;
            fElapsedTime += Time.deltaTime;

            if (fElapsedTime >= 1.0f)
            {
                fElapsedTime = 0f;
                frameCount = 0;
            }
        }
    }
}