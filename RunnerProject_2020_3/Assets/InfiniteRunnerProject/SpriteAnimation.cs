using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteAnimation : MonoBehaviour
    {
        public uint renderInterval = 10;
        public Vector2 pixelSize = new Vector2();

        List<Sprite> _listSprites = new List<Sprite>();
        SpriteRenderer spriteRenderer = null;
        uint _updateCount = 0;
        int _spriteIndex = 0;

        public void Init()
        {
            Sprite[] arrSprites = Resources.LoadAll<Sprite>("RunnerAnimation");

            foreach(Sprite spr in arrSprites)
            {
                _listSprites.Add(spr);
            }

            spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
        }

        public void OnFixedUpdate()
        {
            spriteRenderer.sprite = _listSprites[_spriteIndex];

            if (_updateCount != 0 && _updateCount % renderInterval == 0)
            {
                _spriteIndex++;
            }

            if (_spriteIndex >= _listSprites.Count)
            {
                _spriteIndex = 0;
            }

            _updateCount++;
        }

        public void SetOffset(OffsetType offsetType)
        {
            float xScale = pixelSize.x / _listSprites[0].bounds.size.x;
            float yScale = pixelSize.y / _listSprites[0].bounds.size.y;

            spriteRenderer.transform.localScale = new Vector2(xScale, yScale);

            if (offsetType == OffsetType.BOTTOM_CENTER)
            {
                spriteRenderer.transform.localPosition = new Vector3(0f, _listSprites[0].bounds.size.y * yScale * 0.5f, 0f);
            }
        }
    }
}