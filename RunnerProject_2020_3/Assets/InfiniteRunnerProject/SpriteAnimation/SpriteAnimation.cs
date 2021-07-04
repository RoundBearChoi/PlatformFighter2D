using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteAnimation : MonoBehaviour
    {
        SpriteAnimationSpecs specs;

        [SerializeField] List<Sprite> _listSprites = new List<Sprite>();
        SpriteRenderer spriteRenderer = null;
        int _spriteIndex = 0;

        public StandardInterval mStandardInterval = null;
        public AdditionalIntervals mAdditionalIntervals = new AdditionalIntervals();
        public Hash128 animationHash;
        public bool playOnce = false;

        public int CURRENT_INDEX
        {
            get
            {
                return _spriteIndex;
            }
        }

        public void Init(SpriteAnimationSpecs animationSpecs)
        {
            animationHash = Hash128.Compute(animationSpecs.mSheetFileName);

            specs = animationSpecs;

            //temp (should be done early)
            Sprite[] arrSprites = Resources.LoadAll<Sprite>(specs.mSheetFileName);

            if (arrSprites.Length == 0)
            {
                Debugger.Log("missing sprite resource: " + specs.mSheetFileName);
                arrSprites = Resources.LoadAll<Sprite>("Texture_MissingSprite");
            }

            foreach(Sprite spr in arrSprites)
            {
                _listSprites.Add(spr);
            }

            spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();

            float xScale = specs.mPixelSize.x / _listSprites[0].bounds.size.x;
            float yScale = specs.mPixelSize.y / _listSprites[0].bounds.size.y;

            spriteRenderer.transform.localScale = new Vector2(xScale, yScale);

            //only defined bottom center. later other pivots should be defined as well
            if (specs.mOffsetType == OffsetType.BOTTOM_CENTER)
            {
                spriteRenderer.transform.localPosition = new Vector3(0f, _listSprites[0].bounds.size.y * yScale * 0.5f, 0f);
                spriteRenderer.transform.localPosition += new Vector3(animationSpecs.mAdditionalOffset.x, animationSpecs.mAdditionalOffset.y, 0f);
            }
        }

        public void UpdateSpriteIndex()
        {
            if (mStandardInterval.GetCurrentIntervalCount() == 0)
            {
                IncreaseSpriteIndex();
            }

            LimitSpriteIndex();

            UpdateCurrentSprite();
        }

        public void IncreaseSpriteIndex()
        {
            _spriteIndex++;
        }

        public void LimitSpriteIndex()
        {
            if (_spriteIndex >= _listSprites.Count)
            {
                if (playOnce)
                {
                    _spriteIndex = _listSprites.Count - 1;
                }
                else
                {
                    _spriteIndex = 0;
                }
            }
        }

        public void UpdateCurrentSprite()
        {
            spriteRenderer.sprite = _listSprites[_spriteIndex];
        }

        public void ResetSpriteIndex()
        {
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

        public AdditionalInterval GetAdditionalInterval()
        {
            return mAdditionalIntervals.GetInterval(_spriteIndex);
        }
    }
}