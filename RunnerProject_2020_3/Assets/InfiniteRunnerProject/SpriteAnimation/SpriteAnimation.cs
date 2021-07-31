using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteAnimation : MonoBehaviour
    {
        List<Sprite> _listSprites = new List<Sprite>();
        SpriteRenderer _spriteRenderer = null;

        public SpriteAnimationSpec animationSpec = null;
        public SpriteType spriteType = SpriteType.NONE;

        [Header("Debug")]
        [SerializeField] uint _updateCount = 0;
        [SerializeField] int _spriteIndex = 0;

        public int SPRITE_INDEX
        {
            get
            {
                return _spriteIndex;
            }
        }

        public int SPRITES_COUNT
        {
            get
            {
                return _listSprites.Count;
            }
        }

        public SpriteRenderer SPRITE_RENDERER
        {
            get
            {
                return _spriteRenderer;
            }
        }

        public void LoadSprite(UnitCreationSpec creationSpec, SpriteAnimationSpec spriteSpec)
        {
            animationSpec = spriteSpec;

            Sprite[] arrSprites = ResourceLoader.LoadSpriteBySpec(creationSpec, spriteSpec);

            foreach (Sprite spr in arrSprites)
            {
                _listSprites.Add(spr);
            }

            _spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();

            float xScale = spriteSpec.spriteSize.x / _listSprites[0].bounds.size.x;
            float yScale = spriteSpec.spriteSize.y / _listSprites[0].bounds.size.y;

            _spriteRenderer.transform.localScale = new Vector2(xScale, yScale);

            //other pivots should be defined as well
            if (spriteSpec.offsetType == OffsetType.BOTTOM_CENTER)
            {
                _spriteRenderer.transform.localPosition = new Vector3(0f, _listSprites[0].bounds.size.y * yScale * 0.5f, 0f);
            }
            else if (spriteSpec.offsetType == OffsetType.BOTTOM_LEFT)
            {
                _spriteRenderer.transform.localPosition = new Vector3(_listSprites[0].bounds.size.x * xScale * 0.5f, _listSprites[0].bounds.size.y * yScale * 0.5f, 0f);
            }
            else if (spriteSpec.offsetType == OffsetType.CENTER_LEFT)
            {
                _spriteRenderer.transform.localPosition = new Vector3(_listSprites[0].bounds.size.x * xScale * 0.5f, 0f, 0f);
            }
            else if (spriteSpec.offsetType == OffsetType.CENTER_RIGHT)
            {
                _spriteRenderer.transform.localPosition = new Vector3(-_listSprites[0].bounds.size.x * xScale * 0.5f, 0f, 0f);
            }

            _spriteRenderer.transform.localPosition += new Vector3(spriteSpec.additionalOffset.x, spriteSpec.additionalOffset.y, 0f);
        }
        
        public void UpdateSpriteIndex()
        {
            if (_updateCount != 0 && _updateCount % animationSpec.spriteInterval == 0)
            {
                _spriteIndex++;

                if (_spriteIndex >= int.MaxValue)
                {
                    _spriteIndex = 0;
                }
            }

            _updateCount++;

            if (_updateCount >= uint.MaxValue)
            {
                Debugger.Log("uint max value reached! resetting to 0 (updateCount)");
                _updateCount = 0;
            }

            if (_spriteIndex >= _listSprites.Count)
            {
                if (!animationSpec.playOnce)
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
            _spriteRenderer.sprite = _listSprites[_spriteIndex];
        }

        public void ResetSpriteIndex()
        {
            //Debugger.Log("resetting sprite index: " + animationSpec.name);
            _updateCount = 0;
            _spriteIndex = 0;
        }

        public bool IsOnEnd()
        {
            if (_spriteIndex == _listSprites.Count - 1)
            {
                if (_updateCount % animationSpec.spriteInterval == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void ManualSetSpriteIndex(int index)
        {
            _spriteIndex = index;
        }

        public Sprite GetSprite(int index)
        {
            return _listSprites[index];
        }

        public Vector2 GetSpriteWorldSize(int spriteIndex)
        {
            Sprite sprite = GetSprite(spriteIndex);
            float x = this.gameObject.transform.localScale.x;
            float y = this.gameObject.transform.localScale.y;
            Vector2 worldSize = new Vector2(sprite.bounds.size.x * x, sprite.bounds.size.y * y);

            return worldSize;
        }

        public Vector2[] GetSpriteWorldEdges(int spriteIndex)
        {
            Vector2 worldSize = GetSpriteWorldSize(spriteIndex);

            Vector2[] edges = new Vector2[4];

            edges[0] = new Vector2(this.transform.position.x - (worldSize.x * 0.5f), this.transform.position.y + (worldSize.y * 0.5f));
            edges[1] = new Vector2(this.transform.position.x - (worldSize.x * 0.5f), this.transform.position.y - (worldSize.y * 0.5f));
            edges[2] = new Vector2(this.transform.position.x + (worldSize.x * 0.5f), this.transform.position.y - (worldSize.y * 0.5f));
            edges[3] = new Vector2(this.transform.position.x + (worldSize.x * 0.5f), this.transform.position.y + (worldSize.y * 0.5f));

            return edges;
        }
    }
}