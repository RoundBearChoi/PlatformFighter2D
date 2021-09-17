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

        IEnumerator _setDefaultText()
        {
            Message_HostIPEntered.uiElement = this;

            _inputField = this.gameObject.GetComponentInChildren<InputField>();

            yield return new WaitForEndOfFrame();

            string ip = ClientManager.CURRENT.GetHostIP();
            _inputField.text = ip;
            _inputField.ActivateInputField();

            yield return new WaitForEndOfFrame();

            _inputField.MoveTextEnd(false);
        }
    }
}