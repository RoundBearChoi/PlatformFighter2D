using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class Unit : MonoBehaviour
    {
        public StateController stateController = null;
        public UnitData unitData = null;
        public UnitSprite unitSprite = null;

        private void Start()
        {
            unitData = new UnitData(this.transform);
        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void AttachSprite(UnitSprite sprite, Vector2 pixelSize, OffsetType offsetType)
        {
            unitSprite = sprite;
            
            if (unitSprite.spriteRenderer == null)
            {
                unitSprite.spriteRenderer = unitSprite.gameObject.GetComponentInChildren<SpriteRenderer>();
            }

            float xScale = pixelSize.x / unitSprite.spriteRenderer.sprite.bounds.size.x;
            float yScale = pixelSize.y / unitSprite.spriteRenderer.sprite.bounds.size.y;

            unitSprite.spriteRenderer.transform.localScale = new Vector2(xScale, yScale);

            unitSprite.gameObject.transform.parent = this.transform;
            unitSprite.gameObject.transform.localPosition = Vector3.zero;
            unitSprite.gameObject.transform.localRotation = Quaternion.identity;

            if (offsetType == OffsetType.BOTTOM_CENTER)
            {
                unitSprite.spriteRenderer.transform.localPosition = new Vector3(0f, unitSprite.spriteRenderer.size.y * 0.5f * yScale, 0f);
            }

            Debugger.Log("sprite attached: " + unitSprite.gameObject.name + " " + unitSprite.spriteRenderer.size);
        }

        public virtual void AttachTo(Transform ownerTransform)
        {
            transform.parent = ownerTransform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}