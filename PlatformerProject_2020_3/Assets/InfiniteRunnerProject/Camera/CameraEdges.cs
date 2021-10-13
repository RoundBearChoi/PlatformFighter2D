using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraEdges
    {
        Vector3[] _edges = new Vector3[4];
        //Vector3[] _nearEdges = new Vector3[4];

        Vector3[] _innerEdges = new Vector3[4];
        Vector3[] _outerEdges = new Vector3[4];

        Camera _cam = null;

        public CameraEdges(Camera cam)
        {
            _cam = cam;
        }

        public Vector3 GetEdge(int index)
        {
            return _edges[index];
        }

        public Vector3[] GetEdges()
        {
            return _edges;
        }

        public Vector3[] GetInnerEdges()
        {
            return _innerEdges;
        }

        public Vector3[] GetOuterEdges()
        {
            return _outerEdges;
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

            //top left
            _innerEdges[0] = _cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth * 0.3f, _cam.pixelHeight * 0.7f, _cam.nearClipPlane));
            //bottom left
            _innerEdges[1] = _cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth * 0.3f, _cam.pixelHeight * 0.3f, _cam.nearClipPlane));
            //bottom right
            _innerEdges[2] = _cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth * 0.7f, _cam.pixelHeight * 0.3f, _cam.nearClipPlane));
            //top right
            _innerEdges[3] = _cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth * 0.7f, _cam.pixelHeight * 0.7f, _cam.nearClipPlane));

            foreach (Vector3 edge in _innerEdges)
            {
                Debug.DrawLine(Vector3.zero, edge, Color.green, 0.025f);
            }

            //top left
            _outerEdges[0] = _cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth * 0.1f, _cam.pixelHeight * 0.9f, _cam.nearClipPlane));
            //bottom left
            _outerEdges[1] = _cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth * 0.1f, _cam.pixelHeight * 0.1f, _cam.nearClipPlane));
            //bottom right
            _outerEdges[2] = _cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth * 0.9f, _cam.pixelHeight * 0.1f, _cam.nearClipPlane));
            //top right
            _outerEdges[3] = _cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth * 0.9f, _cam.pixelHeight * 0.9f, _cam.nearClipPlane));

            foreach (Vector3 edge in _outerEdges)
            {
                Debug.DrawLine(Vector3.zero, edge, Color.blue, 0.025f);
            }
        }
    }
}