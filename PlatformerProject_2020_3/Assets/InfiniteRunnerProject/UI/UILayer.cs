using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class UILayer : MonoBehaviour
    {
        [SerializeField]
        protected UISelection _uiSelection;

        [SerializeField]
        protected List<UIElement> _uiElements = new List<UIElement>();

        public virtual void InitLayer(UILayerType uiLayerType)
        {

        }

        public virtual void OnFixedUpdate()
        {
            foreach(UIElement element in _uiElements)
            {
                element.OnFixedUpdate();
            }

            if (_uiSelection != null)
            {
                _uiSelection.OnFixedUpdate();
            }
        }

        public virtual void OnUpdate()
        {
            foreach (UIElement element in _uiElements)
            {
                element.OnUpdate();
            }

            if (_uiSelection != null)
            {
                _uiSelection.OnUpdate();
            }
        }

        public virtual void OnLateUpdate()
        {
            foreach (UIElement element in _uiElements)
            {
                element.OnLateUpdate();

                if (element.messageHandler != null)
                {
                    element.messageHandler.HandleMessages();
                    element.messageHandler.ClearMessages();
                }
            }

            if (_uiSelection != null)
            {
                _uiSelection.OnLateUpdate();
            }
        }
    }
}