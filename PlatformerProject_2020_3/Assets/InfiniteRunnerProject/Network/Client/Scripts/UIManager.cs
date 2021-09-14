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

        [SerializeField]
        Client clientPrefab = null;

        private void Awake()
        {
            SetClientControl(this);
            Instantiate(clientPrefab);
        }

        /// <summary>Attempts to connect to the server.</summary>
        public override void ConnectToServer()
        {
            HideMenu();
            Client.instance.ConnectToServer(BaseClientControl.CURRENT.GetHostIP());
        }

        public override string GetUserName()
        {
            return usernameField.text;
        }

        public override void ShowEnterIPUI()
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
