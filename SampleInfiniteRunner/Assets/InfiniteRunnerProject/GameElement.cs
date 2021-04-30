using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class GameElement : MonoBehaviour
    {
        public GameElementData elementData = null;

        public abstract void Init();

        private void Start()
        {
            elementData = new GameElementData(this.transform);
        }

        public virtual void OnFixedUpdate()
        {

        }
    }
}