using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class UIElement : MonoBehaviour
    {
        public BaseMessageHandler messageHandler = null;

        [SerializeField]
        protected List<UIAnimation> _listUIAnimations = new List<UIAnimation>();

        [SerializeField]
        protected List<UIElement> _listChildElements = new List<UIElement>();

        [SerializeField]
        protected UISelection _uiSelection = null;

        public virtual void InitElement()
        {

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

        public virtual void FindChildAnimations()
        {
            _listUIAnimations.Clear();

            UIAnimation[] arr = this.gameObject.GetComponentsInChildren<UIAnimation>();

            foreach(UIAnimation ani in arr)
            {
                _listUIAnimations.Add(ani);
            }
        }

        public virtual void UpdateSpriteAnimation()
        {
            foreach(UIAnimation ani in _listUIAnimations)
            {
                ani.UpdateSpriteIndex();
            }
        }

        public virtual UIElement AddChildElement(UIElementType elementType)
        {
            UIElement element = Instantiate(ResourceLoader.uiElementLoader.GetObj(elementType)) as UIElement;

            RectTransform rect = element.GetComponent<RectTransform>();
            rect.offsetMax = Vector2.zero;
            rect.offsetMin = Vector2.zero;

            _listChildElements.Add(element);

            element.transform.SetParent(this.transform, false);
            element.InitElement();
            element.FindChildAnimations();

            return element;
        }

        public virtual void OnUpdateChildElements()
        {
            foreach(UIElement element in _listChildElements)
            {
                element.OnUpdate();
            }
        }

        public virtual void OnFixedUpdateChildElements()
        {
            foreach (UIElement element in _listChildElements)
            {
                element.OnFixedUpdate();
            }
        }

        public virtual void OnUpdateUISelection()
        {
            if (_uiSelection != null)
            {
                _uiSelection.OnUpdate();
            }
        }

        public virtual void OnFixedUpdateUISelection()
        {
            if (_uiSelection != null)
            {
                _uiSelection.OnFixedUpdate();
            }
        }
    }
}