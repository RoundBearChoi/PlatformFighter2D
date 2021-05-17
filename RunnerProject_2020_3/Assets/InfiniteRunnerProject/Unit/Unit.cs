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
        //public SpriteAnimation spriteAnimation = null;
        public CollisionDetector collisionDetector = null;

        public List<SpriteAnimation> listSpriteAnimations = new List<SpriteAnimation>();

        private void Start()
        {
            unitData = new UnitData(this.transform);
        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void MatchAnimationToState()
        {
            foreach (SpriteAnimation spriteAni in listSpriteAnimations)
            {
                if (spriteAni.animationHash == stateController.currentState.GetHash())
                {
                    spriteAni.gameObject.SetActive(true);
                }
                else
                {
                    spriteAni.gameObject.SetActive(false);
                }
            }
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
                unitSprite.spriteRenderer.transform.localPosition = new Vector3(0f, unitSprite.spriteRenderer.sprite.bounds.size.y * yScale * 0.5f, 0f);
            }

            Debugger.Log("sprite attached: " + unitSprite.gameObject.name + " " + unitSprite.spriteRenderer.size);
        }

        public virtual void SetParent(Transform ownerTransform)
        {
            transform.parent = ownerTransform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }

        public virtual void OnCollision()
        {

        }
    }
}