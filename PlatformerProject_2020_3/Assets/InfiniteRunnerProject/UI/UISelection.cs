using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class UISelection : MonoBehaviour
    {
        //public BaseMessageHandler messageHandler = null;

        [SerializeField]
        protected List<UIOption> _listOptions = new List<UIOption>();

        [SerializeField]
        protected int _currentSelectionIndex = 0;

        protected InputController _inputController = null;

        protected SelectionArrow _selectionArrow = null;

        public abstract void InitSelection();

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
    }
}