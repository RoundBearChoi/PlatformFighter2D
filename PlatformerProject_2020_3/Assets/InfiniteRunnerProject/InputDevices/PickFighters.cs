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
                if (i < BaseInitializer.current.arrInputDeviceInfo.Length)
                {
                    if (BaseInitializer.current.arrInputDeviceInfo[i] != null)
                    {
                        Vector3 pos = Vector3.Lerp(BaseInitializer.current.arrInputDeviceInfo[i].DEVICE_IMAGE.transform.position, _listFighterSpotInfo[i].DEVICE_ICON_SPOT.position, Time.deltaTime * 4f);
                        BaseInitializer.current.arrInputDeviceInfo[i].DEVICE_IMAGE.transform.position = pos;
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