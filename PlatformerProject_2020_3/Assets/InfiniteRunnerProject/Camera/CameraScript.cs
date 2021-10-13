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
        bool _playerIsOnEdge = false;

        public CameraScript()
        {
            _cameraStateController = new CameraStateController();
            messageHandler = new CameraMessageHandler(this);
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

            _playerIsOnEdge = false;

            foreach (Unit unit in _listViewFighters)
            {
                Vector3[] nearEdges = cameraEdges.GetNearEdges();

                if (nearEdges.Length >= 4)
                {
                    if (unit.transform.position.x <= nearEdges[0].x)
                    {
                        Debugger.Log("player on left!");
                        _playerIsOnEdge = true;
                        break;
                    }

                    if (unit.transform.position.x >= nearEdges[2].x)
                    {
                        Debugger.Log("player on right!");
                        _playerIsOnEdge = true;
                        break;
                    }

                    if (unit.transform.position.y >= nearEdges[0].y)
                    {
                        Debugger.Log("player on top!");
                        _playerIsOnEdge = true;
                        break;
                    }

                    if (unit.transform.position.y <= nearEdges[2].y)
                    {
                        Debugger.Log("player on bottom!");
                        _playerIsOnEdge = true;
                        break;
                    }
                }
            }

            if (!_playerIsOnEdge)
            {
                _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, 10f, 0.005f);
            }
            else
            {
                _camera.orthographicSize += 0.005f;
            }
        }

        public void OnLateUpdate()
        {
            _cameraStateController.OnLateUpdate();
            messageHandler.HandleMessages();
            messageHandler.ClearMessages();
        }

        public void SetCameraState(CameraState cameraState, bool setDefaultState)
        {
            _cameraStateController.SetNewState(cameraState);

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

        public Camera GetCamera()
        {
            return _camera;
        }

        public void SetFollowTarget(GameObject target)
        {
            _target = target;
        }

        public GameObject GetTarget()
        {
            return _target;
        }

        public void UpdateCameraPositionOnTarget(Vector3 pos)
        {
            _camera.transform.position = pos;
        }

        public void RegierViewPlayers(Unit player)
        {
            _listViewFighters.Add(player);
        }
    }
}