using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseUpdater
    {
        protected Unit _unit = null;
        protected uint _totalHitStopFrames = 0;

        public virtual void AddHitStopFrames(uint frames)
        {
            _totalHitStopFrames += frames;
        }

        public abstract void CustomUpdate();
        public abstract void CustomFixedUpdate();
        public abstract void CustomLateUpdate();
    }
}