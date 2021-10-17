using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseInitializer : MonoBehaviour
    {
        public static BaseInitializer CURRENT = null;
        protected BaseStage _stage = null;
        protected BaseStage _modelStage = null;

        [Space(10)] [SerializeField]
        protected List<UnitCreationSpec> listCreationSpecsSO = new List<UnitCreationSpec>();

        [Space(10)]
        [SerializeField]
        protected List<OverlapBoxCollisionData> listOverlapBoxCollisionDataSO = new List<OverlapBoxCollisionData>();

        [Space(10)] [SerializeField]
        protected bool _useDebugLog;

        public SpecsGetter specsGetter = null;
        public StageTransitioner stageTransitioner = null;

        [Space(10)]
        public GameData runnerDataSO = null;
        public FighterData fighterDataSO = null;
        public OldCityParallax oldCityParallaxSO;
        public InputDeviceInfoUI[] arrInputDeviceUI = null;
        public InputDeviceData[] arrInputDeviceData = null;

        public virtual BaseStage STAGE
        {
            get
            {
                return _stage;
            }
        }

        public virtual BaseStage MODEL_STAGE
        {
            get
            {
                return _modelStage;
            }
        }

        public virtual void SetStage(BaseStage stage)
        {
            _stage = stage;
        }

        public virtual void SetModelStage(BaseStage stage)
        {
            _modelStage = stage;
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