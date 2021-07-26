using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseInitializer : MonoBehaviour
    {
        public static BaseInitializer current = null;

        public SpecsGetter specsGetter = null;

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

        public abstract OverlapBoxCollisionData GetHitBoxData(HitBoxDataType boxType);
        public abstract SwampParallax GetParallaxData(ParallaxDataType parallaxType);
        public abstract GameData GetGameData(GameDataType gameDataType);
    }
}