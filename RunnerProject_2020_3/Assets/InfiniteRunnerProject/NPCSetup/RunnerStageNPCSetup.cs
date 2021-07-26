using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerStageNPCSetup : BaseNPCSetup
    {
        Unit _runner = null;

        public RunnerStageNPCSetup(BaseStage ownerStage)
        {
            _stage = ownerStage;
            _runner = ownerStage.units.GetUnit<Runner>();
            _updater = new NPCSetupUpdater(ownerStage, this);
        }

        public override void InstantiateNPC()
        {
            Debugger.Log("npc instantiation triggered");

            Vector3 spawn = _runner.transform.position + new Vector3(10f, 20f, 0f);

            RaycastHit2D hit = Physics2D.Raycast(spawn, Vector2.down, Mathf.Infinity);

            if (hit.collider != null)
            {
                Debug.DrawLine(spawn, hit.point, Color.yellow, 5f);
            }
        }
    }
}