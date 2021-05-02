using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class GameElement : MonoBehaviour
    {
        public GameElementData elementData = null;
        public GameElementSprite elementSprite = new GameElementSprite();

        public abstract void Init();

        private void Start()
        {
            elementData = new GameElementData(this.transform);
        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void AttachSprite(Object obj)
        {
            elementSprite.spriteObj = Instantiate(obj) as GameObject;
            elementSprite.spriteObj.transform.parent = this.transform;
            elementSprite.spriteObj.transform.localPosition = Vector3.zero;
            elementSprite.spriteObj.transform.localRotation = Quaternion.identity;

            elementSprite.spriteRenderer = elementSprite.spriteObj.GetComponentInChildren<SpriteRenderer>();

            Debugger.Log("attaching sprite: " + elementSprite.spriteObj.name + " " + elementSprite.spriteRenderer.size);
        }
    }
}