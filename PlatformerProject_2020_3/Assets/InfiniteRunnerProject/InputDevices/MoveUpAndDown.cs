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
        float _speed = 0f;

        public MoveUpAndDown(RectTransform rect, float upY, float downY, float speed)
        {
            _rect = rect;

            _upY = upY;
            _downY = downY;
            _speed = speed;
        }

        public void OnUpdate()
        {
            if (_rect != null)
            {
                if (_rect.anchoredPosition.y > _upY)
                {
                    if (_speed > 0f)
                    {
                        _speed *= -1f;
                    }
                }

                if (_rect.anchoredPosition.y < _downY)
                {
                    if (_speed < 0f)
                    {
                        _speed *= -1f;
                    }
                }

                _rect.anchoredPosition += (Vector2.up * _speed * Time.deltaTime);
            }
        }
    }
}