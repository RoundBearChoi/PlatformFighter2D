using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class AdditionalInterval
    {
        private int _currentIntervalCount = 0;
        private int _additionalInterval = 0;

        public AdditionalInterval(int additionalInterval)
        {
            _additionalInterval = additionalInterval;
            _currentIntervalCount = additionalInterval;
        }

        public void UpdateInterval()
        {
            _currentIntervalCount--;

            if (_currentIntervalCount < 0)
            {
                _currentIntervalCount = _additionalInterval;
            }
        }

        public int GetCurrentIntervalCount()
        {
            return _currentIntervalCount;
        }
    }
}