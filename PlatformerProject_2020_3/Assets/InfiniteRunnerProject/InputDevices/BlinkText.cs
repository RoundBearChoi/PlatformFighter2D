using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class BlinkText
    {
        uint _showCount = 0;
        uint _hideCount = 0;
        uint _fixedUpdates = 0;
        bool _show = true;
        Text _targetText = null;

        public BlinkText(Text targetText, uint showCount, uint hideCount)
        {
            _targetText = targetText;
            _showCount = showCount;
            _hideCount = hideCount;
        }

        public void OnFixedUpdate()
        {
            _fixedUpdates++;

            if (_show)
            {
                if (_fixedUpdates > _showCount)
                {
                    _fixedUpdates = 0;
                    _show = false;
                }
            }
            else
            {
                if (_fixedUpdates > _hideCount)
                {
                    _fixedUpdates = 0;
                    _show = true;
                }
            }

            _targetText.enabled = _show;
        }
    }
}