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
                _inputs = new bool[6];
            }

            _inputs[0] = ContainsHold(CommandType.MOVE_UP);
            _inputs[1] = ContainsHold(CommandType.MOVE_DOWN);
            _inputs[2] = ContainsHold(CommandType.MOVE_LEFT);
            _inputs[3] = ContainsHold(CommandType.MOVE_RIGHT);
            _inputs[4] = ContainsHold(CommandType.JUMP);
            _inputs[5] = ContainsHold(CommandType.ATTACK_A);

            RB.Client.ClientSend.PlayerMovement(_inputs);
        }

        bool ContainsHold(CommandType commandType)
        {
            UserInput latestInput = _inputController.GetLatestUserInput();

            if (latestInput.commands.ContainsHold(commandType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}