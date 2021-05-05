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

        public virtual void AttachSprite(UnitSprite sprite, OffsetType _offsetType)
        {
            unitSprite = sprite;
                       

            if (unitSprite.spriteRenderer == null)
            {
                unitSprite.spriteRenderer = unitSprite.gameObject.GetComponentInChildren<SpriteRenderer>();
            }

            unitSprite.gameObject.transform.parent = this.transform;
            unitSprite.gameObject.transform.localPosition = Vector3.zero;
            unitSprite.gameObject.transform.localRotation = Quaternion.identity;

            if (_offsetType == OffsetType.BOTTOM_CENTER)
            {
                unitSprite.spriteRenderer.transform.localPosition = new Vector3(0f, unitSprite.spriteRenderer.size.y * 0.5f, 0f);
            }

            Debugger.Log("sprite attached: " + unitSprite.gameObject.name + " " + unitSprite.spriteRenderer.size);
        }

        public virtual void AttachSelf(Transform ownerTransform)
        {
            transform.parent = ownerTransform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}