using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FightersHP : UIElement
    {
        [SerializeField]
        List<FighterHPInfo> _listFighterHPInfo = new List<FighterHPInfo>();

        public override void InitElement()
        {
            _listFighterHPInfo.Clear();

            FighterHPInfo[] arr = this.gameObject.GetComponentsInChildren<FighterHPInfo>();

            foreach(FighterHPInfo h in arr)
            {
                _listFighterHPInfo.Add(h);
            }

            List<Unit> fighters = BaseInitializer.current.STAGE.units.GetUnits<LittleRed>();
            List<Unit> fightersOrdered = new List<Unit>();

            for (int i = fighters.Count - 1; i >= 0; i--)
            {
                fightersOrdered.Add(fighters[i]);
            }

            for (int i = 0; i < fightersOrdered.Count; i++)
            {
                if (_listFighterHPInfo.Count > i)
                {
                    _listFighterHPInfo[i].unit = fightersOrdered[i];
                }
            }

            foreach(FighterHPInfo h in _listFighterHPInfo)
            {
                h.Init();

                if (h.unit == null)
                {
                    h.gameObject.SetActive(false);
                }
            }
        }

        public override void OnUpdate()
        {
            foreach (FighterHPInfo h in _listFighterHPInfo)
            {
                h.OnUpdate();
            }
        }

        public override void OnFixedUpdate()
        {
            foreach (FighterHPInfo h in _listFighterHPInfo)
            {
                h.OnFixedUpdate();
            }
        }

        public override void OnLateUpdate()
        {

        }
    }
}