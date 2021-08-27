using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class IntroSelectionLayer : UILayer
    {
        public override void InitLayer()
        {
            Debugger.Log("starting introselectionlayer");

            UISelection introSelect = Instantiate(ResourceLoader.etcLoader.GetObj(etcType.INTRO_SELECT)) as UISelection;
            AddUISelection(introSelect);
            introSelect.transform.SetParent(this.transform, false);
            introSelect.InitSelection();

            //runnerHPBar.messageHandler = new RunnerHPMessageHandler(runnerHPBar as RunnerHPBar);
        }
    }
}