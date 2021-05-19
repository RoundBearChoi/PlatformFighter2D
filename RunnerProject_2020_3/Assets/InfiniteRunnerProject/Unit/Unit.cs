using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class Unit : MonoBehaviour
    {
        public StateController stateController = null;
        public UnitData unitData = null;
        public CollisionDetector collisionDetector = null;

        public List<SpriteAnimation> listSpriteAnimations = new List<SpriteAnimation>();
        public IUpdater unitUpdater = null;

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
                int n = spriteAni.animationHash.CompareTo(stateController.currentState.GetAnimationHash());

                if (n == 0)
                {
                    spriteAni.gameObject.SetActive(true);
                }
                else
                {
                    spriteAni.gameObject.SetActive(false);
                }
            }
        }

        public virtual void SetUpdater(IUpdater updater)
        {
            unitUpdater = updater;
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