using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseUI : MonoBehaviour
    {
        [SerializeField]
        protected Canvas _canvas = null;

        [SerializeField]
        protected List<UILayer> _uiLayers = new List<UILayer>();

        public Canvas CANVAS
        {
            get
            {
                return _canvas;
            }
        }

        private void Start()
        {
            _canvas = this.gameObject.GetComponentInChildren<Canvas>();
            Init();
        }

        public virtual void Init()
        {

        }

        public virtual void OnFixedUpdate()
        {
            //update the latest layer
            if (_uiLayers.Count > 0)
            {
                _uiLayers[_uiLayers.Count - 1].OnFixedUpdate();
            }
        }

        public virtual void OnUpdate()
        {
            //update the latest layer
            if (_uiLayers.Count > 0)
            {
                _uiLayers[_uiLayers.Count - 1].OnUpdate();
            }
        }

        public virtual void AddUILayer(UILayer layer)
        {
            _uiLayers.Add(layer);
        }
    }
}