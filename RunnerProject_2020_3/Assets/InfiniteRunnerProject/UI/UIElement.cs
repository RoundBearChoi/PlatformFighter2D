using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class UIElement : MonoBehaviour
    {
        public BaseMessageHandler messageHandler = null;

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
    }
}