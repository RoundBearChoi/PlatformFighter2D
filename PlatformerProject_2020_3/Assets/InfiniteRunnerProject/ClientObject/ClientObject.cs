using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    [System.Serializable]
    public class ClientObject : MonoBehaviour
    {
        [SerializeField]
        int _id = 0;

        [SerializeField]
        Vector3 _pos = new Vector3();

        [SerializeField]
        GameObject _playerPositionSphere = null;

        [SerializeField]
        private List<SpriteAnimation> _listSpriteAnimations = new List<SpriteAnimation>();

        private bool _initialized = false;

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public Vector3 POSITION
        {
            get
            {
                return _pos;
            }
        }

        public void SetID(int id)
        {
            _id = id;
        }

        public void SetPosition(Vector3 pos)
        {
            _pos = pos;
        }

        public void UpdatePosition()
        {
            _playerPositionSphere.transform.position = _pos;
        }

        public void AddSpriteAnimation(string spriteName)
        {
            if (!_initialized)
            {
                _initialized = true;
                _listSpriteAnimations = new List<SpriteAnimation>();
            }

            GameObject obj = new GameObject(spriteName);
            obj.transform.parent = _playerPositionSphere.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            _listSpriteAnimations.Add(obj.AddComponent<SpriteAnimation>());

            Sprite[] arr = ResourceLoader.LoadSpriteByString(spriteName);

            if (arr != null)
            {
                if (arr.Length > 0)
                {
                    //_listSpriteAnimations[_listSpriteAnimations.Count - 1].AddSpriteArray(arr);
                }
            }
        }
    }
}