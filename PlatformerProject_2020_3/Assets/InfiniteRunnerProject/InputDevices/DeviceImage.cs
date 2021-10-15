using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    [System.Serializable]
    public class DeviceImage
    {
        [SerializeField]
        Transform _objTransform = null;

        [SerializeField]
        Image _pcImage = null;

        [SerializeField]
        Image _psImage = null;

        public void Init(Transform objTransform)
        {
            _objTransform = objTransform;

            _pcImage = objTransform.Find("pc").GetComponent<Image>();
            _psImage = objTransform.Find("ps").GetComponent<Image>();
        }

        public void TogglePCImage(bool toggle)
        {
            _pcImage.enabled = toggle;
        }

        public void TogglePSImage(bool toggle)
        {
            _psImage.enabled = toggle;
        }

        public Transform TRANSFORM
        {
            get
            {
                return _objTransform;
            }
        }
    }
}