using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class PickFighters : UIElement
    {
        [Space(10)]
        [SerializeField]
        List<FighterSpotInfo> _listFighterSpotInfo = new List<FighterSpotInfo>();

        public override void InitElement()
        {
            _listFighterSpotInfo.Clear();

            FighterSpotInfo[] arr = this.gameObject.GetComponentsInChildren<FighterSpotInfo>();

            foreach(FighterSpotInfo spot in arr)
            {
                _listFighterSpotInfo.Add(spot);
                spot.Init();
            }
        }

        public override void OnUpdate()
        {

        }

        public override void OnFixedUpdate()
        {

        }

        public override void OnLateUpdate()
        {

        }
    }
}