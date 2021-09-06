using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB.Client
{
    public class UIManager : BaseClientControl
    {
        public GameObject startMenu;
        public InputField usernameField;

        private void Awake()
        {
            SetClientControl(this);
        }

        /// <summary>Attempts to connect to the server.</summary>
        public override void ConnectToServer()
        {
            HideMenu();
            Client.instance.ConnectToServer();
        }

        public override string GetUserName()
        {
            return usernameField.text;
        }

        public override void ShowMenu()
        {
            startMenu.SetActive(true);
            usernameField.interactable = true;
        }

        public override void HideMenu()
        {
            startMenu.SetActive(false);
            usernameField.interactable = false;
        }
    }
}
