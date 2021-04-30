using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class GameElement : MonoBehaviour
    {
        public GameElementData elementData = null;

        public virtual void OnFixedUpdate()
        {

        }
    }
}