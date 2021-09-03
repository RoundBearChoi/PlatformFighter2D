using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class UIElement : MonoBehaviour
    {
        public BaseMessageHandler messageHandler = null;

        [SerializeField]
        List<UIAnimation> _listUIAnimations = new List<UIAnimation>();

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
    }
}