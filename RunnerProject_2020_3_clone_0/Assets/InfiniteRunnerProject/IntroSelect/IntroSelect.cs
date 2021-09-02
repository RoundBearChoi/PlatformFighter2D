using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RB
{
    public class IntroSelect : UISelection
    {
        Keyboard _keyboard = null;

        public override void InitSelection()
        {
            _keyboard = Keyboard.current;

            _listOptions.Clear();

            UIOption[] arr = this.gameObject.GetComponentsInChildren<UIOption>();

            foreach(UIOption option in arr)
            {
                _listOptions.Add(option);
            }

            _selectionArrow = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.SELECTION_ARROW)) as SelectionArrow;
        }

        public override void OnFixedUpdate()
        {

        }

        public override void OnUpdate()
        {
            if (_keyboard.upArrowKey.wasPressedThisFrame)
            {
                UpSelection();
            }

            if (_keyboard.downArrowKey.wasPressedThisFrame)
            {
                DownSelection();
            }

            if (_keyboard.enterKey.wasPressedThisFrame)
            {
                _listOptions[_currentSelectionIndex].OnEnterKey();
            }
        }

        public override void OnLateUpdate()
        {
            UpdateSelectionArrowPosition();
        }
    }
}