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
        Vector3 _networkPosition = new Vector3();

        [SerializeField]
        GameObject _networkPositionSphere = null;

        [SerializeField]
        GameObject _playerPositionSphere = null;

        [SerializeField]
        private List<SpriteAnimation> _listSpriteAnimations = new List<SpriteAnimation>();

        [SerializeField]
        SpriteAnimation _currentAnimation = null;

        Unit _offlineDummy = null;

        private bool _initialized = false;

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public void SetID(int id)
        {
            _id = id;
        }

        public void SetDummyUnit(Unit dummy)
        {
            _offlineDummy = dummy;
        }

        public void SetNetworkPosition(Vector3 pos)
        {
            _networkPosition = pos;
            _networkPositionSphere.transform.position = pos;
        }

        public void FixedUpdatePosition()
        {
            if (_offlineDummy != null)
            {
                _playerPositionSphere.transform.position = Vector3.Lerp(_playerPositionSphere.transform.position, _offlineDummy.transform.position, 0.7f);
            }
            else
            {
                _playerPositionSphere.transform.position = Vector3.Lerp(_playerPositionSphere.transform.position, _networkPosition, 0.7f);
            }
        }

        public void UpdatePosition()
        {
            if (_offlineDummy != null)
            {
                _playerPositionSphere.transform.position = Vector3.Lerp(_playerPositionSphere.transform.position, _offlineDummy.transform.position, Time.deltaTime * 10f);
            }
            else
            {
                _playerPositionSphere.transform.position = Vector3.Lerp(_playerPositionSphere.transform.position, _networkPosition, Time.deltaTime * 10f);
            }
        }

        public GameObject GetPlayerSphere()
        {
            return _playerPositionSphere;
        }

        public void UpdateDirection(bool facingRight)
        {
            if (facingRight)
            {
                if (_playerPositionSphere.transform.rotation.y != 0f)
                {
                    _playerPositionSphere.transform.rotation = Quaternion.Euler(_playerPositionSphere.transform.rotation.x, 0f, _playerPositionSphere.transform.rotation.z);
                }
            }
            else
            {
                if (_playerPositionSphere.transform.rotation.y != 180f)
                {
                    _playerPositionSphere.transform.rotation = Quaternion.Euler(_playerPositionSphere.transform.rotation.x, 180f, _playerPositionSphere.transform.rotation.z);
                }
            }
        }

        public void AddSpriteAnimations(UnitCreationSpec creationSpec)
        {
            if (!_initialized)
            {
                _initialized = true;
                _listSpriteAnimations = new List<SpriteAnimation>();
            }

            foreach (SpriteAnimationSpec aniSpec in creationSpec.listSpriteAnimationSpecs)
            {
                AddSpriteAnimation(aniSpec);
            }
        }

        void AddSpriteAnimation(SpriteAnimationSpec spec)
        {
            foreach(string str in spec.listSpriteNames)
            {
                GameObject obj = new GameObject(str);

                obj.transform.parent = _playerPositionSphere.transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
                _listSpriteAnimations.Add(obj.AddComponent<SpriteAnimation>());

                Sprite[] arr = ResourceLoader.LoadSpriteByString(str);

                if (arr != null)
                {
                    if (arr.Length > 0)
                    {
                        _listSpriteAnimations[_listSpriteAnimations.Count - 1].SetSpriteAnimationSpec(spec);
                        _listSpriteAnimations[_listSpriteAnimations.Count - 1].AddSpriteArray(arr);
                    }
                }
            }
        }

        public void SetAnimation(SpriteType spriteType)
        {
            foreach(SpriteAnimation ani in _listSpriteAnimations)
            {
                if (ani.ANIMATION_SPEC != null)
                {
                    if (ani.ANIMATION_SPEC.spriteType == spriteType)
                    {
                        ani.gameObject.SetActive(true);

                        ani.ResetSpriteIndex();
                        ani.UpdateSpriteOnIndex();

                        _currentAnimation = ani;
                    }
                    else
                    {
                        ani.gameObject.SetActive(false);
                    }
                }
            }
        }

        public SpriteAnimation GetCurrentAnimation()
        {
            return _currentAnimation;
        }
    }
}