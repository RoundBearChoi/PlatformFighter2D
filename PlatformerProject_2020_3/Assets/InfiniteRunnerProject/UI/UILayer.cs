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

        public virtual void AddUISelection(UISelection selection)
        {
            //clear anchor (left, right, top, bottom)
            RectTransform rect = selection.GetComponent<RectTransform>();
            rect.offsetMax = Vector2.zero;
            rect.offsetMin = Vector2.zero;

            _uiSelection = selection;
        }

        public virtual void AddUISelection(UIType uiType)
        {
            UISelection uiSelection = Instantiate(ResourceLoader.uiLoader.GetObj(uiType)) as UISelection;

            AddUISelection(uiSelection);
            uiSelection.transform.SetParent(this.transform, false);
            uiSelection.InitSelection();
        }

        public virtual void AttachElementToLayer(UIElement element)
        {
            //clear anchor (left, right, top, bottom)
            RectTransform rect = element.GetComponent<RectTransform>();
            rect.offsetMax = Vector2.zero;
            rect.offsetMin = Vector2.zero;

            _uiElements.Add(element);
        }

        public virtual UIElement AddUIElement(UIElementType elementType)
        {
            UIElement element = Instantiate(ResourceLoader.uiElementLoader.GetObj(elementType)) as UIElement;

            AttachElementToLayer(element);
            element.transform.SetParent(this.transform, false);
            element.InitElement();
            element.FindChildAnimations();

            return element;
        }
    }
}