using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : BaseInitializer
    {
        private void Start()
        {
            Application.targetFrameRate = 144;
            Screen.SetResolution(1920, 1080, true);

            current = this;
            Debugger.Log("setting current GameInitializer instance");

            ResourceLoader.Init();

            specsGetter = new SpecsGetter(listCreationSpecsSO);
            stageTransitioner = new StageTransitioner();

            //first stage
            stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.INTRO_STAGE));
        }

        private void Update()
        {
            Debugger.useLog = _useDebugLog;

            stageTransitioner.Update();

            if (_stage != null)
            {
                _stage.OnUpdate();
            }
        }

        private void FixedUpdate()
        {
            RB.Network.ThreadControl.OnFixedUpdate();

            if (_stage != null)
            {
                _stage.OnFixedUpdate();
            }
        }

        private void LateUpdate()
        {
            if (_stage != null)
            {
                _stage.OnLateUpdate();
            }
        }

        public void FindAllDefaultCreationSpecs()
        {
            UnitCreationSpec[] arr = Resources.FindObjectsOfTypeAll(typeof(UnitCreationSpec)) as UnitCreationSpec[];

            listCreationSpecsSO.Clear();

            foreach(UnitCreationSpec spec in arr)
            {
                listCreationSpecsSO.Add(spec);
            }
        }

        public void FindAllOverlapBoxCollisionDataSpecs()
        {
            OverlapBoxCollisionData[] arr = Resources.FindObjectsOfTypeAll(typeof(OverlapBoxCollisionData)) as OverlapBoxCollisionData[];

            listOverlapBoxCollisionDataSO.Clear();

            foreach (OverlapBoxCollisionData data in arr)
            {
                listOverlapBoxCollisionDataSO.Add(data);
            }
        }
    }
}