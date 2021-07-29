using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : BaseInitializer
    {
        private void Start()
        {
            current = this;
            Debugger.Log("setting current GameInitializer instance");

            ResourceLoader.Init();

            //first stage
            IStageTransition intro = new IntroStageTransition(this);
            _stage = intro.MakeTransition();
            _stage.Init();
            
            specsGetter = new SpecsGetter(listCreationSpecsSO);
            stageTransitioner = new StageTransitioner();
        }

        private void Update()
        {
            Debugger.useLog = _useDebugLog;

            stageTransitioner.Update();
            _stage.OnUpdate();
        }

        private void FixedUpdate()
        {
            _stage.OnFixedUpdate();
        }

        private void LateUpdate()
        {
            _stage.OnLateUpdate();
        }

        public void FindAllDefaultCreationSpecs()
        {
            DefaultUnitCreationSpec[] arr = Resources.FindObjectsOfTypeAll(typeof(DefaultUnitCreationSpec)) as DefaultUnitCreationSpec[];

            listCreationSpecsSO.Clear();

            foreach(DefaultUnitCreationSpec spec in arr)
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