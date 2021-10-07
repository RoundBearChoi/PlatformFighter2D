using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class FighterHPInfo : MonoBehaviour
    {
        public static float zeroHP_Padding = 169.6f;

        [SerializeField]
        float hpPercentage = 0f;

        [SerializeField]
        RectMask2D _rectMask2D_orange = null;

        [SerializeField]
        RectMask2D _rectMask2D_red = null;

        public Unit unit = null;

        public void OnFixedUpdate()
        {
            if (unit != null)
            {
                hpPercentage = (float)unit.unitData.hp / (float)unit.unitData.initialHP;
            }
        }
    }
}