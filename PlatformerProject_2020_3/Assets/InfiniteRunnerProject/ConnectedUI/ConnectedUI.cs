using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class ConnectedUI : UIElement
    {
        [SerializeField]
        HorizontalLayoutGroup _horizontalGroup = null;

        public override void InitElement()
        {
            ConnectedPlayerInfo connectedPlayerInfo = Instantiate(ResourceLoader.etcLoader.GetObj(etcType.CONNECTED_PLAYER_INFO)) as ConnectedPlayerInfo;
            connectedPlayerInfo.transform.SetParent(_horizontalGroup.transform, false);
            connectedPlayerInfo.SetPlayerNumber("PLAYER 1");
        }
    }
}