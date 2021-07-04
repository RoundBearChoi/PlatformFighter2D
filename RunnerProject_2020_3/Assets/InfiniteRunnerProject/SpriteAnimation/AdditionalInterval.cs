using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public class AdditionalInterval
    {
        [SerializeField] int _intervalAmount = 0;
        [SerializeField] int _targetSpriteIndex = 0;
        int _leftoverIntervals = 0;

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