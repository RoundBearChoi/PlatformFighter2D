using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FighterSpotInfo : MonoBehaviour
    {
        [SerializeField]
        Transform _deviceIconSpot = null;

        public Transform DEVICE_ICON_SPOT
        {
            get
            {
                return _deviceIconSpot;
            }
        }

        public void Init()
        {

        }
    }
}