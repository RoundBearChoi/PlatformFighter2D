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
            foreach (UIElement element in _uiElements)
            {
                element.OnUpdate();
            }
        }

        public virtual void AddUIElement(UIElement element)
        {
            _uiElements.Add(element);
        }
    }
}