using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB.Client
{
    public class UIManager : BaseClientControl
    {
        public static UIManager instance;

        public GameObject startMenu;
        public InputField usernameField;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Debug.Log("Instance already exists, destroying object!");
                Destroy(this);
            }
        }

        /// <summary>Attempts to connect to the server.</summary>
        public override void ConnectToServer()
        {
            HideMenu();
            Client.instance.ConnectToServer();
        }

        public void HideMenu()
        {
            startMenu.SetActive(false);
            usernameField.interactable = false;
        }

        public void ShowMenu()
        {
            startMenu.SetActive(true);
            usernameField.interactable = true;
        }
    }
}
