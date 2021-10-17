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
            for (int i = 0; i < _listFighterSpotInfo.Count; i++)
            {
                if (i < BaseInitializer.CURRENT.arrInputDeviceUI.Length)
                {
                    if (BaseInitializer.CURRENT.arrInputDeviceUI[i] != null)
                    {
                        Vector3 pos = Vector3.Lerp(BaseInitializer.CURRENT.arrInputDeviceUI[i].deviceImage.TRANSFORM.position, _listFighterSpotInfo[i].DEVICE_ICON_SPOT.position, Time.deltaTime * BaseInitializer.CURRENT.fighterDataSO.InputDeviceIconMoveSpeed);
                        BaseInitializer.CURRENT.arrInputDeviceUI[i].deviceImage.TRANSFORM.position = pos;
                    }
                }
            }
        }

        public override void OnFixedUpdate()
        {

        }

        public override void OnLateUpdate()
        {

        }
    }
}