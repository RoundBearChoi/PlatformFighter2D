using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    //temp: needs to be cleaned up
    public class UIAnimation : MonoBehaviour
    {
        [SerializeField]
        string _spriteName = string.Empty;

        [SerializeField]
        Image _image = null;

        [SerializeField]
        List<Sprite> _listSprites = new List<Sprite>();

        [SerializeField]
        int _spriteIndex = 0;

        [SerializeField]
        uint _interval = 0;

        [SerializeField]
        uint _updateCount = 0;

        private void Start()
        {
            _listSprites.Clear();
            _image = this.gameObject.GetComponentInChildren<Image>();

            if (!string.IsNullOrEmpty(_spriteName))
            {
                Sprite[] arr = ResourceLoader.LoadSpriteByString(_spriteName);

                foreach (Sprite spr in arr)
                {
                    _listSprites.Add(spr);
                }

                if (_listSprites.Count > 0)
                {
                    _image.sprite = _listSprites[0];
                }
            }
        }

        public void UpdateSpriteIndex()
        {
            _updateCount++;

            if (_updateCount > 0 && _updateCount % _interval == 0)
            {
                _updateCount = 0;
                _spriteIndex++;

                if (_spriteIndex >= _listSprites.Count)
                {
                    _spriteIndex = 0;
                }

                _image.sprite = _listSprites[_spriteIndex];
            }
        }
    }
}