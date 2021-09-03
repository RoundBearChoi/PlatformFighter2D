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
                if (_canvas == null)
                {
                    _canvas = this.gameObject.GetComponentInChildren<Canvas>();
                }

                return _canvas;
            }
        }

        public virtual void Init(BaseUIType baseUIType)
        {

        }

        public virtual void OnFixedUpdate()
        {
            if (_uiLayers.Count > 0)
            {
                _uiLayers[_uiLayers.Count - 1].OnFixedUpdate();
            }
        }

        public virtual void OnUpdate()
        {
            //only update the latest layer
            if (_uiLayers.Count > 0)
            {
                _uiLayers[_uiLayers.Count - 1].OnUpdate();
            }
        }

        public virtual void OnLateUpdate()
        {
            if (_uiLayers.Count > 0)
            {
                _uiLayers[_uiLayers.Count - 1].OnLateUpdate();
            }
        }

        public virtual void AddUILayer(UILayer layer)
        {
            _uiLayers.Add(layer);
        }
    }
}