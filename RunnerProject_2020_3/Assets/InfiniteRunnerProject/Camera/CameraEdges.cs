using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraEdges
    {
        Vector3[] _edges = new Vector3[4];
        Camera _cam = null;

        public CameraEdges(Camera cam)
        {
            _cam = cam;
        }

        public void FixedUpdateEdges()
        {
            //top left
            _edges[0] = _cam.ScreenToWorldPoint(new Vector3(0f, _cam.pixelHeight, _cam.nearClipPlane));
            //bottom left
            _edges[1] = _cam.ScreenToWorldPoint(new Vector3(0f, 0f, _cam.nearClipPlane));
            //bottom right
            _edges[2] = _cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth, 0f, _cam.nearClipPlane));
            //top right
            _edges[3] = _cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth, _cam.pixelHeight, _cam.nearClipPlane));

            foreach(Vector3 edge in _edges)
            {
                Debug.DrawLine(Vector3.zero, edge, Color.yellow, 0.025f);
            }
        }
    }
}