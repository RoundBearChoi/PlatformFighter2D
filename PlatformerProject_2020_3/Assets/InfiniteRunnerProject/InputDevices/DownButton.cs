using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    [System.Serializable]
    public class DownButton
    {
        [SerializeField]
        Transform _transform = null;

        [SerializeField]
        Image _pressedImage = null;

        [SerializeField]
        Image _nonPressedImage = null;

        uint _fixedUpdateCount = 0;
        uint _pressedFrames = 35;
        uint _nonPressedFrames = 35;
        bool _showPressed = false;
        bool _hideAll = false;

        public void Init(Transform transform)
        {
            _transform = transform;

            _pressedImage = transform.Find("PressedImage").GetComponent<Image>();
            _nonPressedImage = transform.Find("NonPressedImage").GetComponent<Image>();
        }

        public Transform TRANSFORM
        {
            get
            {
                return _transform;
            }
        }

        public void OnFixedUpdate()
        {
            _fixedUpdateCount++;

            if (_showPressed)
            {
                if (_fixedUpdateCount > _pressedFrames)
                {
                    _fixedUpdateCount = 0;
                    _showPressed = false;
                }
            }
            else
            {
                if (_fixedUpdateCount > _nonPressedFrames)
                {
                    _fixedUpdateCount = 0;
                    _showPressed = true;
                }
            }

            if (!_hideAll)
            {
                if (_showPressed)
                {
                    _pressedImage.enabled = true;
                    _nonPressedImage.enabled = false;
                }
                else
                {
                    _pressedImage.enabled = false;
                    _nonPressedImage.enabled = true;
                }
            }
            else
            {
                _pressedImage.enabled = false;
                _nonPressedImage.enabled = false;
            }
        }

        public void HideImages(bool hide)
        {
            _hideAll = hide;
        }
    }
}