using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class RunnerHPBar : UIElement
    {
        [SerializeField]
        RectMask2D rectMask2D_red = null;

        [SerializeField]
        RectMask2D rectMask2D_orange = null;

        [SerializeField]
        float _paddingAmountWhenHealthIsZero = 0;

        float _orangePercentage = 1f;
        float _currentHPPercentage = 1f;

        public override void InitElement()
        {
            RunnerHPUpdateMessage.uiElement = this;
        }

        public void UpdateRedBar(float hpPercentage)
        {
            float paddingAmount = _paddingAmountWhenHealthIsZero * (1f - hpPercentage);
            rectMask2D_red.padding = new Vector4(0f, 0f, paddingAmount, 0f);

            _currentHPPercentage = hpPercentage;
        }

        public void LerpOrangeBar()
        {
            _orangePercentage = Mathf.Lerp(_orangePercentage, _currentHPPercentage, 0.065f);

            float paddingAmount = _paddingAmountWhenHealthIsZero * (1f - _orangePercentage);
            rectMask2D_orange.padding = new Vector4(0f, 0f, paddingAmount, 0f);
        }
    }
}