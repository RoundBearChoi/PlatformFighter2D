using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RB.Client;

namespace RB
{
    public class EnterHostIP : UIElement
    {
        [SerializeField]
        InputField _inputField = null;

        public override void InitElement()
        {
            StartCoroutine(_setDefaultText());
        }

        public override void OnFixedUpdate()
        {
            //if (!_inputField.isFocused)
            //{
            //    BaseClientControl.CURRENT.SetHostIP(_inputField.text);
            //}
        }

        IEnumerator _setDefaultText()
        {
            _inputField = this.gameObject.GetComponentInChildren<InputField>();

            yield return new WaitForEndOfFrame();

            _inputField.text = "127.0.0.1";
            _inputField.ActivateInputField();

            yield return new WaitForEndOfFrame();

            _inputField.MoveTextEnd(false);
        }
    }
}