using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OldCity : MonoBehaviour
    {
        [SerializeField]
        GameObject FencesAndIron = null;

        private void Start()
        {
            Vector3 pos = new Vector3(FencesAndIron.transform.position.x, FencesAndIron.transform.position.y, BaseInitializer.current.fighterDataSO.OldCity_Fences_z);

            FencesAndIron.transform.position = pos;
        }
    }
}