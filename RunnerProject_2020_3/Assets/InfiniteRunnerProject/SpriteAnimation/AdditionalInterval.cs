using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class AdditionalInterval
    {
        private int _intervalAmount = 0;
        private int _leftoverIntervals = 0;
        private int _targetSpriteIndex = 0;

        public AdditionalInterval(int intervalAmount, int targetSpriteIndex)
        {
            _intervalAmount = intervalAmount;
            _leftoverIntervals = intervalAmount;
            _targetSpriteIndex = targetSpriteIndex;
            
        }

        public int TARGET_SPRITE_INDEX
        {
            get
            {
                return _targetSpriteIndex;
            }
        }

        public int LEFTOVER_INTERVALS
        {
            get
            {
                return _leftoverIntervals;
            }
        }

        public void Reset()
        {
            _leftoverIntervals = _intervalAmount;
        }

        public void ProcessInterval()
        {
            _leftoverIntervals--;
        }
    }
}