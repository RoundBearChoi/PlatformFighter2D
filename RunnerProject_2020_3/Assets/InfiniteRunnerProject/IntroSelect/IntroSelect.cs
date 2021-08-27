using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class IntroSelect : UISelection
    {
        public override void InitSelection()
        {
            _listOptions.Clear();

            UIOption[] arr = this.gameObject.GetComponentsInChildren<UIOption>();

            foreach(UIOption option in arr)
            {
                _listOptions.Add(option);
            }
        }

        public override void OnFixedUpdate()
        {

        }

        public override void OnUpdate()
        {

        }
    }
}