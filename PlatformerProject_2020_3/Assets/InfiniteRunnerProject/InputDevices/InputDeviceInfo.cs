using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class InputDeviceInfo : MonoBehaviour
    {
        [SerializeField]
        InputDeviceType _inputDeviceType = InputDeviceType.NONE;

        [SerializeField]
        Image _pcImage = null;

        [SerializeField]
        Image _psImage = null;

        private void Start()
        {
            _pcImage.enabled = false;
            _psImage.enabled = false;

            if (_inputDeviceType == InputDeviceType.PC)
            {
                _pcImage.enabled = true;
            }

            else if (_inputDeviceType == InputDeviceType.PS4)
            {
                _psImage.enabled = true;
            }
        }
    }
}