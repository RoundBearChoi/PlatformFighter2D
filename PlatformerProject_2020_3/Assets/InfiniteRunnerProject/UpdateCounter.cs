using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UpdateCounter
    {
        int count = 0;
        int FPS = 0;
        float fElapsedTime = 0f;

        public int GetCount()
        {
            return FPS;
        }

        public void OnUpdate()
        {
            count++;
            fElapsedTime += Time.deltaTime;

            if (fElapsedTime >= 1.0f)
            {
                FPS = count;
                fElapsedTime = 0f;
                count = 0;
            }
        }
    }
}