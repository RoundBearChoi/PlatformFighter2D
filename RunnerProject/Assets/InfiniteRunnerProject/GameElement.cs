using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class GameElement : MonoBehaviour
    {
        public StateController stateController = null;
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
                       

            if (elementSprite.spriteRenderer == null)
            {
                elementSprite.spriteRenderer = elementSprite.gameObject.GetComponentInChildren<SpriteRenderer>();
            }

            elementSprite.gameObject.transform.parent = this.transform;
            elementSprite.gameObject.transform.localPosition = Vector3.zero;
            elementSprite.gameObject.transform.localRotation = Quaternion.identity;

            if (_offsetType == OffsetType.BOTTOM_CENTER)
            {
                elementSprite.spriteRenderer.transform.localPosition = new Vector3(0f, elementSprite.spriteRenderer.size.y * 0.5f, 0f);
            }

            Debugger.Log("sprite attached: " + elementSprite.gameObject.name + " " + elementSprite.spriteRenderer.size);
        }

        public virtual void AttachSelf(Transform ownerTransform)
        {
            transform.parent = ownerTransform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}