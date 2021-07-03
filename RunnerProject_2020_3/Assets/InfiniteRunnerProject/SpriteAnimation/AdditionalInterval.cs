using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class AdditionalInterval
    {
        public int IntervalAmount = 0;
        public int Current = 0;
        public int TargetSpriteIndex = 0;

        public AdditionalInterval(int intervalAmount, int targetSpriteIndex)
        {
            IntervalAmount = intervalAmount;
            Current = intervalAmount;
            TargetSpriteIndex = targetSpriteIndex;
            
        }

        public void Reset()
        {
            Current = IntervalAmount;
        }

        public void ProcessInterval()
        {
            Current--;
        }
    }
}