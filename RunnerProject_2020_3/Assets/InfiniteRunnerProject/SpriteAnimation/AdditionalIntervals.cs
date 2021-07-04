using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class AdditionalIntervals
    {
        private Dictionary<int, AdditionalInterval> _dicIntervals = new Dictionary<int, AdditionalInterval>();

        public void AddInterval(int targetSpriteIndex, int interval)
        {
            if (!_dicIntervals.ContainsKey(targetSpriteIndex))
            {
                _dicIntervals.Add(targetSpriteIndex, new AdditionalInterval(interval));
            }
        }

        public AdditionalInterval GetInterval(int spriteIndex)
        {
            if (_dicIntervals.ContainsKey(spriteIndex))
            {
                if (_dicIntervals[spriteIndex].GetCurrentIntervalCount() <= 0)
                {
                    return null;
                }
                else
                {
                    return _dicIntervals[spriteIndex];
                }
            }
            else
            {
                return null;
            }
        }

        public void ResetCount()
        {
            foreach(KeyValuePair<int, AdditionalInterval> data in _dicIntervals)
            {
                data.Value.ResetCurrentCount();
            }
        }
    }
}