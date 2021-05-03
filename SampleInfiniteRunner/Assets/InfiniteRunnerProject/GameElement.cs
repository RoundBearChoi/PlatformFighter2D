using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class GameElement : MonoBehaviour
    {
        public GameElementData elementData = null;
        public GameElementSprite elementSprite = null;

        public abstract void Init();

        private void Start()
        {
            elementData = new GameElementData(this.transform);
        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void AttachSprite(GameElementSprite sprite, OffsetType _offsetType)
        {
            elementSprite = sprite;
            elementSprite.gameObject.transform.parent = this.transform;
            elementSprite.gameObject.transform.localPosition = Vector3.zero;
            elementSprite.gameObject.transform.localRotation = Quaternion.identity;
            
            elementSprite.spriteRenderer = elementSprite.gameObject.GetComponentInChildren<SpriteRenderer>();
            
            Debugger.Log("attaching sprite: " + elementSprite.gameObject.name + " " + elementSprite.spriteRenderer.size);
        }
    }
}