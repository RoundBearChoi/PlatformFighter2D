using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class ClientInputSender : MonoBehaviour
    {
        [SerializeField]
        protected bool[] _inputs = null;

        public virtual void SendInputToServer()
        {
            if (_inputs == null || _inputs.Length == 0)
            {
                _inputs = new bool[7];
            }

            UserInput input = GameInitializer.current.GetStage().inputController.GetFirstUserInput();

            _inputs[0] = input.commands.ContainsPress(CommandType.MOVE_UP, false);
            _inputs[1] = input.commands.ContainsPress(CommandType.MOVE_DOWN, false);
            _inputs[2] = input.commands.ContainsPress(CommandType.MOVE_LEFT, false);
            _inputs[3] = input.commands.ContainsPress(CommandType.MOVE_RIGHT, false);
            _inputs[4] = input.commands.ContainsPress(CommandType.JUMP, false);
            _inputs[5] = input.commands.ContainsPress(CommandType.ATTACK_A, false);
            _inputs[6] = input.commands.ContainsPress(CommandType.SHIFT, false);

            RB.Client.ClientSend.SendClientInput(_inputs);
        }
    }
}