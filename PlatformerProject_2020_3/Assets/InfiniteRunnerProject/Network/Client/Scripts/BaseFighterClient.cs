using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class BaseFighterClient : MonoBehaviour
    {
        [SerializeField]
        protected bool[] _inputs = null;
        protected InputController _inputController = null;


        public virtual void Init()
        {
            _inputController = GameInitializer.current.GetStage().GetInputController();
        }

        public virtual void SendInputToServer()
        {

        }
    }
}