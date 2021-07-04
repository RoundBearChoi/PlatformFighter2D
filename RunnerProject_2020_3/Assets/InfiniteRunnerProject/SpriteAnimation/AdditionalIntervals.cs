using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class AdditionalIntervals
    {
        private Dictionary<uint, AdditionalInterval> _dicIntervals = new Dictionary<uint, AdditionalInterval>();

        public void AddInterval(uint targetSpriteIndex, int interval)
        {
            if (!_dicIntervals.ContainsKey(targetSpriteIndex))
            {
                _dicIntervals.Add(targetSpriteIndex, new AdditionalInterval(interval));
            }
        }
    }
}