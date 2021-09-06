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
            if (_inputs == null || _inputs.Length == 0)
            {
                _inputs = new bool[5];
            }

            UserInput latestInput = _inputController.GetLatestUserInput();

            if (latestInput.commands.ContainsPress(CommandType.MOVE_UP, true))
            {
                _inputs[0] = true;
            }

            RB.Client.ClientSend.PlayerMovement(_inputs);
        }
    }
}