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

        public void Init(SpriteAnimationSpecs animationSpecs)
        {
            specs = animationSpecs;

            //temp (should be done early)
            Sprite[] arrSprites = Resources.LoadAll<Sprite>(specs.SheetFileName);

            foreach(Sprite spr in arrSprites)
            {
                _listSprites.Add(spr);
            }

            spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();

            float xScale = specs.pixelSize.x / _listSprites[0].bounds.size.x;
            float yScale = specs.pixelSize.y / _listSprites[0].bounds.size.y;

            spriteRenderer.transform.localScale = new Vector2(xScale, yScale);

            if (specs.offsetType == OffsetType.BOTTOM_CENTER)
            {
                spriteRenderer.transform.localPosition = new Vector3(0f, _listSprites[0].bounds.size.y * yScale * 0.5f, 0f);
            }
        }

        public void OnFixedUpdate()
        {
            spriteRenderer.sprite = _listSprites[_spriteIndex];

            if (_updateCount != 0 && _updateCount % specs.renderInterval == 0)
            {
                _spriteIndex++;
            }

            if (_spriteIndex >= _listSprites.Count)
            {
                _spriteIndex = 0;
            }

            _updateCount++;
        }
    }
}