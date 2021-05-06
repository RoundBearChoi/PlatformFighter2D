using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpriteAnimation : MonoBehaviour
    {
        public uint renderInterval = 10;

        List<Sprite> _listSprites = new List<Sprite>();
        SpriteRenderer spriteRenderer = null;
        uint _updateCount = 0;
        int _spriteIndex = 0;

        private void Start()
        {
            Sprite[] arrSprites = Resources.LoadAll<Sprite>("RunnerAnimation");

            foreach(Sprite spr in arrSprites)
            {
                _listSprites.Add(spr);
            }

            spriteRenderer = GetComponent<SpriteRenderer>();
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
    }
}