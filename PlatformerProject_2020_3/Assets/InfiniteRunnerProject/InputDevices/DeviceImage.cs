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

        [SerializeField]
        Image _playerIcon = null;

        [SerializeField]
        Text _playerIndex = null;

        public void Init(Transform objTransform)
        {
            _objTransform = objTransform;

            _pcImage = objTransform.Find("pc").GetComponent<Image>();
            _psImage = objTransform.Find("ps").GetComponent<Image>();
            _playerIcon = objTransform.Find("playerNumber").GetComponent<Image>();
            _playerIndex = _playerIcon.transform.Find("playerNumberText").GetComponent<Text>();
        }

        public void TogglePCImage(bool toggle)
        {
            _pcImage.enabled = toggle;
        }

        public void TogglePSImage(bool toggle)
        {
            _psImage.enabled = toggle;
        }

        public void TogglePlayerIcon(bool toggle)
        {
            _playerIcon.enabled = toggle;
        }

        public void SetPlayerIndex(string text)
        {
            _playerIndex.text = text;
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