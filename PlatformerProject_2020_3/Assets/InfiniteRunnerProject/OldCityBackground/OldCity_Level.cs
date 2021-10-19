using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OldCity_Level : MonoBehaviour
    {
        [SerializeField]
        GameObject FencesAndIron = null;

        [SerializeField]
        GameObject Fog = null;

        private void Start()
        {
            Vector3 fencePos = new Vector3(FencesAndIron.transform.position.x, FencesAndIron.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.OldCity_Fences_z);
            FencesAndIron.transform.position = fencePos;

            Vector3 fogPos = new Vector3(Fog.transform.position.x, Fog.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.OldCity_BottomFog_z);
            Fog.transform.position = fogPos;
        }
    }
}