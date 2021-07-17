using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseUI : MonoBehaviour
    {
        [SerializeField]
        protected Canvas _canvas = null;

        private void Start()
        {
            _canvas = this.gameObject.GetComponentInChildren<Canvas>();
        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnUpdate()
        {

        }
    }
}