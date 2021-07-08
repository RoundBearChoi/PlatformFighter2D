using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteAnimation : MonoBehaviour
    {
        SpriteAnimationSpecs specs;

        List<Sprite> _listSprites = new List<Sprite>();
        List<AdditionalInterval> _listAdditionalIntervals = new List<AdditionalInterval>();
        SpriteRenderer spriteRenderer = null;
        uint _updateCount = 0;
        int _spriteIndex = 0;

        public Hash128 animationHash;
        public bool playOnce = false;

        public int SPRITE_INDEX
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

            //should be done early (resourceloader)
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

            //later other pivots should be defined as well
            if (specs.mOffsetType == OffsetType.BOTTOM_CENTER)
            {
                spriteRenderer.transform.localPosition = new Vector3(0f, _listSprites[0].bounds.size.y * yScale * 0.5f, 0f);
                spriteRenderer.transform.localPosition += new Vector3(animationSpecs.mAdditionalOffset.x, animationSpecs.mAdditionalOffset.y, 0f);
            }
            else if (specs.mOffsetType == OffsetType.BOTTOM_LEFT)
            {
                spriteRenderer.transform.localPosition = new Vector3(_listSprites[0].bounds.size.x * xScale * 0.5f, _listSprites[0].bounds.size.y * yScale * 0.5f, 0f);
                spriteRenderer.transform.localPosition += new Vector3(animationSpecs.mAdditionalOffset.x, animationSpecs.mAdditionalOffset.y, 0f);
            }
        }

        public void AddAdditionalInterval(AdditionalInterval interval)
        {
            _listAdditionalIntervals.Add(interval);
        }

        public bool ProcessingAdditionalInterval()
        {
            foreach (AdditionalInterval interval in _listAdditionalIntervals)
            {
                if (_spriteIndex == interval.TARGET_SPRITE_INDEX)
                {
                    interval.ProcessInterval();

                    if (interval.LEFTOVER_INTERVALS > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        public void ResetAdditionalIntervals()
        {
            foreach (AdditionalInterval interval in _listAdditionalIntervals)
            {
                interval.ResetCount();
            }
        }

        public void UpdateSpriteIndex()
        {
            if (_updateCount != 0 && _updateCount % specs.mRenderInterval == 0)
            {
                _spriteIndex++;

                //only reset after going to next index
                ResetAdditionalIntervals();
            }

            _updateCount++;

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
        }

        public void UpdateSpriteOnIndex()
        {
            spriteRenderer.sprite = _listSprites[_spriteIndex];
        }

        public void ResetSpriteIndex()
        {
            _updateCount = 0;
            _spriteIndex = 0;
        }

        public bool IsOnEnd()
        {
            if (_spriteIndex == _listSprites.Count - 1)
            {
                if (_updateCount % specs.mRenderInterval == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}