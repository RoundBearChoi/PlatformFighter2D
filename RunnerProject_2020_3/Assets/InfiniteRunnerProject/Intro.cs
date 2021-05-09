using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Intro : MonoBehaviour
    {
        Camera mainCam = null;

        private void Start()
        {
            mainCam = FindObjectOfType<Camera>();
            mainCam.transform.position = new Vector3(0f, 0f, -5f);
        }
    }
}