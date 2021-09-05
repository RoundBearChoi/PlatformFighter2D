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

            _selectionArrow = GameObject.Instantiate(ResourceLoader.uiLoader.GetObj(UIType.SELECTION_ARROW)) as SelectionArrow;

            _inputController = GameInitializer.current.GetStage().GetInputController();
        }

        public override void OnFixedUpdate()
        {

        }

        public override void OnUpdate()
        {
            if (_inputController.GetLatestUserInput().commands.ContainsPress(CommandType.MOVE_UP, true))
            {
                UpSelection();
            }

            if (_inputController.GetLatestUserInput().commands.ContainsPress(CommandType.MOVE_DOWN, true))
            {
                DownSelection();
            }

            if (_inputController.GetLatestUserInput().commands.ContainsPress(CommandType.ATTACK_A, true))
            {
                _listOptions[_currentSelectionIndex].OnEnterKey();
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