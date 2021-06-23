using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteAnimation : MonoBehaviour
    {
        SpriteAnimationSpecs specs;

        List<Sprite> _listSprites = new List<Sprite>();
        SpriteRenderer spriteRenderer = null;
        uint _updateCount = 0;
        int _spriteIndex = 0;

        public Hash128 animationHash;
        public bool playOnce = false;

        public void Init(SpriteAnimationSpecs animationSpecs)
        {
            animationHash = Hash128.Compute(animationSpecs.mSheetFileName);

            specs = animationSpecs;

            //temp (should be done early)
            Sprite[] arrSprites = Resources.LoadAll<Sprite>(specs.mSheetFileName);

            foreach(Sprite spr in arrSprites)
            {
                _listSprites.Add(spr);
            }

            spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();

            float xScale = specs.mPixelSize.x / _listSprites[0].bounds.size.x;
            float yScale = specs.mPixelSize.y / _listSprites[0].bounds.size.y;

            spriteRenderer.transform.localScale = new Vector2(xScale, yScale);

            if (specs.mOffsetType == OffsetType.BOTTOM_CENTER)
            {
                spriteRenderer.transform.localPosition = new Vector3(0f, _listSprites[0].bounds.size.y * yScale * 0.5f, 0f);
                spriteRenderer.transform.localPosition += new Vector3(animationSpecs.mAdditionalOffset.x, animationSpecs.mAdditionalOffset.y, 0f);
            }
        }

        public void OnFixedUpdate()
        {
            spriteRenderer.sprite = _listSprites[_spriteIndex];

            if (_updateCount != 0 && _updateCount % specs.mRenderInterval == 0)
            {
                _spriteIndex++;
            }

            if (_spriteIndex >= _listSprites.Count)
            {
                if (!playOnce)
                {
                    _spriteIndex = 0;
                }
                else
                {
                    _spriteIndex = _listSprites.Count - 1;
                }
            }

            _updateCount++;
        }

        public void Reset()
        {
            _updateCount = 0;
            _spriteIndex = 0;
        }

        public bool IsOnEnd()
        {
            if (_spriteIndex == _listSprites.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}