using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OnESC : UIElement
    {
        public override void InitElement()
        {

        }

        public override void OnUpdate()
        {
            UserInput userInput = BaseInitializer.current.GetStage().inputController.GetPCUserInput();

            if (userInput != null)
            {
                if (userInput.commands.ContainsPress(CommandType.ESCAPE, true))
                {
                    if (_listChildElements.Count == 0)
                    {
                        UIElement uiElement = UIElement.AddUIElement(UIElementType.QUIT_GAME_ASK, this.transform);
                        _listChildElements.Add(uiElement);
                    }
                    else
                    {
                        ClearChildElements();
                    }
                }
            }

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

        public void ClearChildElements()
        {
            foreach (UIElement element in _listChildElements)
            {
                Destroy(element.gameObject);
            }

            _listChildElements.Clear();
        }
    }
}