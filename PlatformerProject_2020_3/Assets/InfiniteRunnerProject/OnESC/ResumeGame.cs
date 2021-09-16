using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ResumeGame : UIOption
    {
        public override void OnEnterKey()
        {
            BaseMessage clearOnEscapeElements = new Message_ClearOnEscapeChildElements();
            clearOnEscapeElements.Register();
        }
    }
}