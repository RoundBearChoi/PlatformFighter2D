using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class UILayer : MonoBehaviour
    {
        [SerializeField]
        protected List<UIElement> _uiElements = new List<UIElement>();

        public virtual void InitLayer()
        {

        }

        public virtual void OnFixedUpdate()
        {
            foreach(UIElement element in _uiElements)
            {
                element.OnFixedUpdate();
            }
        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnLateUpdate()
        {
            foreach (UIElement element in _uiElements)
            {
                element.OnUpdate();

                element.messageHandler.HandleMessages();
                element.messageHandler.ClearMessages();
            }
        }

        public virtual void AddUIElement(UIElement element)
        {
            _uiElements.Add(element);
        }
    }
}