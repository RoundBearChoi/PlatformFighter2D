using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerStageNPCSetup : BaseNPCSetup
    {
        Unit _runner = null;
        CameraScript _cameraScript = null;

        public RunnerStageNPCSetup(BaseStage ownerStage)
        {
            _stage = ownerStage;
            _runner = ownerStage.units.GetUnit<Runner>();
            _updater = new NPCSetupUpdater(ownerStage, this);
            _cameraScript = GameInitializer.current.GetStage().cameraScript;
        }

        public override void InstantiateNPC()
        {
            Debugger.Log("npc instantiation triggered");

            Vector3[] edges = _cameraScript.cameraEdges.GetEdges();
            Vector3 spawn = new Vector3(edges[3].x + GameInitializer.current.runnerDataSO.EnemyCreationCushionX, 20f, 0f);

            RaycastHit2D hit = Physics2D.Raycast(spawn, Vector2.down, Mathf.Infinity);

            if (hit.collider != null)
            {
                Debug.DrawLine(spawn, hit.point, Color.yellow, 4f);

                GameInitializer.current.GetStage().InstantiateUnits_ByUnitType(UnitType.GOLEM);
                Unit golem = GameInitializer.current.GetStage().units.GetUnit<Golem>();
                golem.transform.position = hit.point;
            }
        }
    }
}