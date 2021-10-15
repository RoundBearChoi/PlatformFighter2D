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
                if (i < BaseInitializer.current.arrInputDeviceUI.Length)
                {
                    if (BaseInitializer.current.arrInputDeviceUI[i] != null)
                    {
                        Vector3 pos = Vector3.Lerp(BaseInitializer.current.arrInputDeviceUI[i].deviceImage.TRANSFORM.position, _listFighterSpotInfo[i].DEVICE_ICON_SPOT.position, Time.deltaTime * BaseInitializer.current.fighterDataSO.InputDeviceIconMoveSpeed);
                        BaseInitializer.current.arrInputDeviceUI[i].deviceImage.TRANSFORM.position = pos;
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