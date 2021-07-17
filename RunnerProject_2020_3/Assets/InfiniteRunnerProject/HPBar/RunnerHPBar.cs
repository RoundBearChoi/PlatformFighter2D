using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class RunnerHPBar : UIElement
    {
        RectMask2D rectMask2D = null;

        [SerializeField]
        float _paddingAmountWhenHealthIsZero = 0;

        public override void InitElement()
        {
            RunnerHPUpdateMessage.uiElement = this;

            rectMask2D = this.gameObject.GetComponentInChildren<RectMask2D>();
        }

        public void UpdateBar(float hpPercentage)
        {
            float paddingAmount = _paddingAmountWhenHealthIsZero * (1f - hpPercentage);
            rectMask2D.padding = new Vector4(0f, 0f, paddingAmount, 0f);
        }
    }
}