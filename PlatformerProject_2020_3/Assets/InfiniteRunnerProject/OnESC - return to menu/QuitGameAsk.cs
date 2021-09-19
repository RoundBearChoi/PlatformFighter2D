using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class QuitGameAsk : UIElement
    {
        public override void InitElement()
        {
            UISelection quitAsk = UISelection.AddUISelection(UIType.QUIT_GAME_ASK_SELECT, this.transform);
            _uiSelection = quitAsk;
        }

        public override void OnFixedUpdate()
        {
            OnFixedUpdateUISelection();
        }

        public override void OnUpdate()
        {
            OnUpdateUISelection();
        }

        public override void OnLateUpdate()
        {
            OnLateUpdateUISelection();
        }
    }
}