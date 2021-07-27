using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public class ComboHitCount
    {
        [SerializeField] private uint _count;
        [SerializeField] private uint _fixedUpdates;

        public ComboHitCount()
        {
            _count = 0;
            _fixedUpdates = 0;
        }

        public void AddCount()
        {
            _count++;
        }

        public uint GetCount()
        {
            return _count;
        }

        public void OnFixedUpdate()
        {
            _fixedUpdates++;

            if (_fixedUpdates >= 70)
            {
                _fixedUpdates = 0;

                if (_count > 0)
                {
                    _count--;
                }
            }
        }
    }
}