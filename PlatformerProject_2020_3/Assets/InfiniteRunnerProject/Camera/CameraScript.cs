using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraScript
    {
        public BaseMessageHandler messageHandler = null;
        public CameraEdges cameraEdges = null;

        IStateController<CameraState> _cameraStateController = null;
        GameObject _target = null;
        Camera _camera = null;
        List<Unit> _listViewFighters = new List<Unit>();
        bool _playerIsOnInnerEdge = false;
        bool _playerIsOnOuterEdge = false;

        public CameraScript()
        {
            _cameraStateController = new CameraStateController();
            messageHandler = new CameraMessageHandler(this);
        }

        public Camera CAMERA
        {
            get
            {
                return _camera;
            }
        }

        public GameObject TARGET_OBJ
        {
            get
            {
                return _target;
            }
        }

        public void OnUpdate()
        {
            _cameraStateController.OnUpdate();
        }

        public void OnFixedUpdate()
        {
            _cameraStateController.OnFixedUpdate();
            _cameraStateController.GetCurrentState().cameraUpdateCount++;

            cameraEdges.FixedUpdateEdges();

            ZoomInOut();
        }

        public void OnLateUpdate()
        {
            _cameraStateController.OnLateUpdate();
            messageHandler.HandleMessages();
            messageHandler.ClearMessages();
        }

        public void SetCameraState(CameraState cameraState, bool setDefaultState)
        {
            _cameraStateController.SetNewState(null, cameraState);

            if (setDefaultState)
            {
                CameraState.defaultState = cameraState;
            }
        }

        public void SetCamera(Camera camera)
        {
            _camera = camera;
            cameraEdges = new CameraEdges(_camera);
        }

        public void SetFollowTarget(GameObject target)
        {
            _target = target;
        }

        public void RegisterViewPlayers(Unit player)
        {
            _listViewFighters.Add(player);
        }

        bool ZoomOnWinner()
        {
            foreach (Unit unit in _listViewFighters)
            {
                if (unit.hp <= 0)
                {
                    _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, 10f, 0.01f);
                    return true;
                }
            }

            return false;
        }

        void ZoomInOut()
        {
            _playerIsOnInnerEdge = false;
            _playerIsOnOuterEdge = false;

            if (_listViewFighters.Count == 0)
            {
                return;
            }

            if (!ZoomOnWinner())
            {
                foreach (Unit unit in _listViewFighters)
                {
                    Vector3[] innerEdges = cameraEdges.GetInnerEdges();

                    if (innerEdges.Length >= 4)
                    {
                        if (unit.transform.position.x <= innerEdges[0].x)
                        {
                            _playerIsOnInnerEdge = true;
                            break;
                        }

                        if (unit.transform.position.x >= innerEdges[2].x)
                        {
                            _playerIsOnInnerEdge = true;
                            break;
                        }

                        if (unit.transform.position.y >= innerEdges[0].y)
                        {
                            _playerIsOnInnerEdge = true;
                            break;
                        }

                        if (unit.transform.position.y <= innerEdges[2].y)
                        {
                            _playerIsOnInnerEdge = true;
                            break;
                        }
                    }
                }

                foreach (Unit unit in _listViewFighters)
                {
                    Vector3[] outerEdges = cameraEdges.GetOuterEdges();

                    if (outerEdges.Length >= 4)
                    {
                        if (unit.transform.position.x <= outerEdges[0].x)
                        {
                            _playerIsOnOuterEdge = true;
                            break;
                        }

                        if (unit.transform.position.x >= outerEdges[2].x)
                        {
                            _playerIsOnOuterEdge = true;
                            break;
                        }

                        if (unit.transform.position.y >= outerEdges[0].y)
                        {
                            _playerIsOnOuterEdge = true;
                            break;
                        }

                        if (unit.transform.position.y <= outerEdges[2].y)
                        {
                            _playerIsOnOuterEdge = true;
                            break;
                        }
                    }
                }

                if (_playerIsOnOuterEdge)
                {
                    _camera.orthographicSize += BaseInitializer.CURRENT.fighterDataSO.CameraZoomOutRate;
                }
                else if (!_playerIsOnInnerEdge)
                {
                    if (_camera.orthographicSize > 10f)
                    {
                        _camera.orthographicSize -= BaseInitializer.CURRENT.fighterDataSO.CameraZoomInRate;
                    }
                }
            }
        }
    }
}