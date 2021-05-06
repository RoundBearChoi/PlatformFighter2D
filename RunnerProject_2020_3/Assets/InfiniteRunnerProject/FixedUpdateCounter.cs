using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FixedUpdateCounter
    {
        int count = 0;
        int fixedUpdatesPerSec = 0;
        float fElapsedTime = 0f;

        public int GetCount()
        {
            return fixedUpdatesPerSec;
        }

        public void OnFixedUpdate()
        {
            count++;
            fElapsedTime += Time.deltaTime;

            if (fElapsedTime >= 1.0f)
            {
                //Debugger.Log("frame count: " + count);
                fixedUpdatesPerSec = count;
                fElapsedTime = 0f;
                count = 0;
            }
        }
    }
}