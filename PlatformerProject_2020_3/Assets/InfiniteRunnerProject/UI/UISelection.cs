using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RB
{
    public abstract class UISelection : MonoBehaviour
    {
        [SerializeField]
        protected List<UIOption> _listOptions = new List<UIOption>();

        [SerializeField]
        protected int _currentSelectionIndex = 0;
        protected InputController _inputController = null;
        protected SelectionArrow _selectionArrow = null;

        public virtual void InitSelection()
        {
            _listOptions.Clear();

            UIOption[] arr = this.gameObject.GetComponentsInChildren<UIOption>();

            foreach (UIOption option in arr)
            {
                _listOptions.Add(option);
            }

            _inputController = GameInitializer.current.GetStage().GetInputController();
            _selectionArrow = GameObject.Instantiate(ResourceLoader.uiLoader.GetObj(UIType.SELECTION_ARROW)) as SelectionArrow;
        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnLateUpdate()
        {

        }

        public virtual void UpSelection()
        {
            _currentSelectionIndex--;

            if (_currentSelectionIndex < 0)
            {
                _currentSelectionIndex = _listOptions.Count - 1;
            }
        }

        public virtual void DownSelection()
        {
            _currentSelectionIndex++;

            if (_currentSelectionIndex >= _listOptions.Count)
            {
                _currentSelectionIndex = 0;
            }
        }

        public virtual void UpdateSelectionArrowPosition()
        {
            _selectionArrow.transform.SetParent(_listOptions[_currentSelectionIndex].transform, false);
        }

        public virtual void UpdateSelection()
        {
            UserInput latestInput = _inputController.GetLatestUserInput();

            //game keys
            if (latestInput.commands.ContainsPress(CommandType.MOVE_UP, true))
            {
                UpSelection();
            }

            if (latestInput.commands.ContainsPress(CommandType.MOVE_DOWN, true))
            {
                DownSelection();
            }

            //non game keys
            if (latestInput.commands.ContainsPress(CommandType.ARROW_UP, true))
            {
                UpSelection();
            }
            if (latestInput.commands.ContainsPress(CommandType.ARROW_DOWN, true))
            {
                DownSelection();
            }

            OnSelect();
        }

        public virtual void OnSelect()
        {
            //only use mouse when hovering
            //if (_inputController.GetLatestUserInput().commands.ContainsPress(CommandType.ATTACK_A, true))
            //{
            //    _listOptions[_currentSelectionIndex].OnEnterKey();
            //    return;
            //}

            if (_inputController.GetLatestUserInput().commands.ContainsPress(CommandType.ENTER, true))
            {
                _listOptions[_currentSelectionIndex].OnEnterKey();
                return;
            }
        }
    }
}