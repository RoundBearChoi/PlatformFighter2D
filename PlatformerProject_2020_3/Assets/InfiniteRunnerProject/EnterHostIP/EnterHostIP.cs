using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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