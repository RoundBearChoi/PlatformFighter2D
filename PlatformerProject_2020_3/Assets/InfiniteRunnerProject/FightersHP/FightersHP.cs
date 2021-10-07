using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FightersHP : UIElement
    {
        [SerializeField]
        List<Unit> _listFighters = new List<Unit>();

        [SerializeField]
        List<FighterHPInfo> _listFighterHPInfo = new List<FighterHPInfo>();

        public override void InitElement()
        {
            _listFighterHPInfo.Clear();

            FighterHPInfo[] arr = this.gameObject.GetComponentsInChildren<FighterHPInfo>();

            foreach(FighterHPInfo f in arr)
            {
                _listFighterHPInfo.Add(f);
            }

            //Debugger.Log("--- initializing fighter hp bars ---");

            List<Unit> fighters = BaseInitializer.current.GetStage().units.GetUnits<LittleRed>();

            for (int i = 0; i < fighters.Count; i++)
            {
                if (_listFighterHPInfo.Count > i)
                {
                    _listFighterHPInfo[i].unit = fighters[i];
                }
            }
        }

        public override void OnUpdate()
        {
            //InputController inputController = BaseInitializer.current.GetStage().GetInputController();
            //UserInput userInput = inputController.GetUserInput(InputType.PLAYER_ONE);
            //
            //if (userInput.commands.ContainsPress(CommandType.ESCAPE, true))
            //{
            //    if (_listChildElements.Count == 0)
            //    {
            //        UIElement uiElement = UIElement.AddUIElement(UIElementType.QUIT_GAME_ASK, this.transform);
            //        _listChildElements.Add(uiElement);
            //    }
            //    else
            //    {
            //        ClearChildElements();
            //    }
            //}
            //

            OnUpdateChildElements();
        }

        public override void OnFixedUpdate()
        {
            OnFixedUpdateChildElements();
        }

        public override void OnLateUpdate()
        {
            OnLateUpdateChildElements();
        }
    }
}