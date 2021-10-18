using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FighterSpotInfo : MonoBehaviour
    {
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
            _deviceIconSpot = this.transform.Find("DeviceIconSpot").GetComponent<Transform>();
        }
    }
}