using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    [System.Serializable]
    public class MoveUpAndDown
    {
        [SerializeField]
        private RectTransform _rect = null;

        [SerializeField]
        float _upY = 0f;

        [SerializeField]
        float _downY = 0f;

        [SerializeField]
        float _currentSpeed = 0f;

        [SerializeField]
        float _upSpeed = 0f;

        [SerializeField]
        float _downSpeed = 0f;

        public MoveUpAndDown(RectTransform rect, float upY, float downY, float upSpeed, float downSpeed)
        {
            _rect = rect;

            _upY = upY;
            _downY = downY;
            _upSpeed = upSpeed;
            _downSpeed = downSpeed;
            _currentSpeed = downSpeed;
        }

        public void OnUpdate()
        {
            if (_rect != null)
            {
                if (_rect.anchoredPosition.y > _upY)
                {
                    if (_currentSpeed > 0f)
                    {
                        _currentSpeed = _downSpeed;
                    }
                }

                if (_rect.anchoredPosition.y < _downY)
                {
                    if (_currentSpeed < 0f)
                    {
                        _currentSpeed = _upSpeed;
                    }
                }

                _rect.anchoredPosition += (Vector2.up * _currentSpeed * Time.deltaTime);
            }
        }
    }
}