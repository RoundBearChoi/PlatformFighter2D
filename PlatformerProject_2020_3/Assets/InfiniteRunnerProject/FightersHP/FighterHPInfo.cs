using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class FighterHPInfo : MonoBehaviour
    {
        public static float zeroHP_Padding = 169.6f;

        bool _initialized = false;

        [SerializeField]
        float _hpPercentage = 0f;

        [SerializeField]
        float _orangePercentage = 0f;

        [SerializeField]
        float _redPercentage = 0f;

        [SerializeField]
        RectMask2D _rectMask2D_orange = null;

        [SerializeField]
        RectMask2D _rectMask2D_red = null;

        public Unit unit = null;

        public void Init()
        {
            _orangePercentage = 1f;
            _hpPercentage = 1f;
        }

        public void OnFixedUpdate()
        {
            if (unit != null)
            {
                _hpPercentage = (float)unit.unitData.hp / (float)unit.unitData.initialHP;
            }

            _orangePercentage = Mathf.Lerp(_orangePercentage, _hpPercentage, 0.03f);
            _redPercentage = _hpPercentage;
        }

        public void OnUpdate()
        {
            float orangePadding = zeroHP_Padding * (1f - _orangePercentage);
            _rectMask2D_orange.padding = new Vector4(0f, 0f, orangePadding, 0f);

            float redPadding = zeroHP_Padding * (1f - _redPercentage);
            _rectMask2D_red.padding = new Vector4(0f, 0f, redPadding, 0f);
        }
    }
}