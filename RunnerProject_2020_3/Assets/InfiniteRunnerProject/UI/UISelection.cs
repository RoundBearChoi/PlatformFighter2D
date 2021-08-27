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

        public virtual void InitSelection()
        {

        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnUpdate()
        {

        }
    }
}