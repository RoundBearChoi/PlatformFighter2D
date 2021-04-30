using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class GameElement : MonoBehaviour
    {
        public float UpVelocity = 0f;

        public virtual void OnFixedUpdate()
        {

        }
    }
}