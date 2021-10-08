using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseInitializer : MonoBehaviour
    {
        public static BaseInitializer current = null;
        public SpecsGetter specsGetter = null;
        public StageTransitioner stageTransitioner = null;

        [Space(10)] [SerializeField]
        protected List<UnitCreationSpec> listCreationSpecsSO = new List<UnitCreationSpec>();

        [Space(10)]
        [SerializeField]
        protected List<OverlapBoxCollisionData> listOverlapBoxCollisionDataSO = new List<OverlapBoxCollisionData>();

        [Space(10)] [SerializeField]
        protected bool _useDebugLog;

        [Space(10)]
        public GameData runnerDataSO = null;
        public FighterData fighterDataSO = null;
        public SwampParallax swampParallaxSO;
        public OldCityParallax oldCityParallaxSO;
        public InputDeviceInfo[] arrInputDeviceInfo = null;

        protected BaseStage _stage = null;

        public virtual BaseStage GetStage()
        {
            return _stage;
        }

        public virtual void SetStage(BaseStage stage)
        {
            _stage = stage;
        }

        public virtual void RunCoroutine(IEnumerator enumerator)
        {
            StartCoroutine(enumerator);
        }

        public OverlapBoxCollisionData GetOverlapBoxCollisionData(OverlapBoxDataType dataType)
        {
            foreach(OverlapBoxCollisionData data in listOverlapBoxCollisionDataSO)
            {
                if (data.overlapBoxDataType == dataType)
                {
                    return data;
                }
            }

            return null;
        }
    }
}