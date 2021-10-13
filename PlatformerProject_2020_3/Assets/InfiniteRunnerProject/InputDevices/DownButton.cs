using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class DownButton : MonoBehaviour
    {
        [SerializeField]
        Image _nonPressedImage = null;

        [SerializeField]
        Image _pressedImage = null;

        uint _fixedUpdateCount = 0;
        uint _pressedFrames = 30;
        uint _nonPressedFrames = 50;
        bool _showPressed = false;
        bool _hideAll = false;

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