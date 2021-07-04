using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StandardInterval
    {
        private int _standardInterval = 0;
        private int _currentIntervalCount = 0;

        public StandardInterval(int standardInterval)
        {
            _standardInterval = standardInterval;
            _currentIntervalCount = standardInterval;
        }

        public void UpdateInterval()
        {
            _currentIntervalCount--;

            if (_currentIntervalCount < 0)
            {
                _currentIntervalCount = _standardInterval;
            }
        }

        public int GetCurrentIntervalCount()
        {
            return _currentIntervalCount;
        }
    }
}