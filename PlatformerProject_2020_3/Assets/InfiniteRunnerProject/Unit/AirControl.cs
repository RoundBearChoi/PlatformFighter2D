using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public class AirControl
    {
        [SerializeField]
        float _horizontalMomentum = 0f;

        public bool DashTriggered = false;
        public bool UppercutTriggered = false;

        public float HORIZONTAL_MOMENTUM
        {
            get
            {
                return _horizontalMomentum;
            }
        }

        public void SetMomentum(float momentum)
        {
            _horizontalMomentum = momentum;
        }

        public void AddMomentum(float additional)
        {
            _horizontalMomentum += additional;
        }
    }
}