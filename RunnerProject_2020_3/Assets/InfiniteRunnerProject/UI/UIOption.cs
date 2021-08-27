using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UIOption : MonoBehaviour
    {
        public virtual void OnEnterKey()
        {
            Debugger.Log("on enterkey: " + this.gameObject.name);
        }
    }
}