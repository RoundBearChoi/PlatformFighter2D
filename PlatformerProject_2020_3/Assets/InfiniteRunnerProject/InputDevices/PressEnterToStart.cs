using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class PressEnterToStart : UIElement
    {
        BlinkText _blinkText = null;

        [Space(10)]
        [SerializeField]
        Text _targetText = null;

        public override void InitElement()
        {
            _blinkText = new BlinkText(_targetText, 50, 50);
        }

        public override void OnFixedUpdate()
        {
            //_blinkText.OnFixedUpdate();
        }

        public override void OnUpdate()
        {

        }

        public override void OnLateUpdate()
        {

        }
    }
}