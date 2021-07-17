using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class UILayer : MonoBehaviour
    {
        [SerializeField]
        protected List<UIElement> _uiElements = new List<UIElement>();

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnUpdate()
        {

        }
    }
}