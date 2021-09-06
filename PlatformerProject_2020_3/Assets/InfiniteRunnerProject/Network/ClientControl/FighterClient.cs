using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class FighterClient : BaseFighterClient
    {
        public override void SendInputToServer()
        {
            if (_inputs == null || _inputs.Length == 0)
            {
                _inputs = new bool[5];
            }

            UserInput latestInput = _inputController.GetLatestUserInput();

            if (latestInput.commands.ContainsHold(CommandType.MOVE_UP))
            {
                Debugger.Log("true");
                _inputs[0] = true;
            }
            else
            {
                _inputs[0] = false;
            }

            RB.Client.ClientSend.PlayerMovement(_inputs);
        }
    }
}