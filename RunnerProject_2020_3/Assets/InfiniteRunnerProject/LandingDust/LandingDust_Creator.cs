using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LandingDust_Creator : UnitCreator
    {
        private Transform _parentTransform;

        public LandingDust_Creator(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public override Unit DefineUnit()
        {
            Unit landingDust = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.LANDING_DUST)) as Unit;
            landingDust.transform.parent = _parentTransform;
            landingDust.transform.localRotation = Quaternion.identity;

            landingDust.unitData = new UnitData(landingDust.transform);

            landingDust.iStateController = new StateController(
                new LandingDust_DefaultState(landingDust),
                landingDust.unitData);

            landingDust.unitData.spriteAnimations = new SpriteAnimations(landingDust.iStateController);

            landingDust.unitData.spriteAnimations.AddSpriteAnimation(
                "landing dust animation",
                new SpriteAnimationSpecs(
                    StaticRefs.movementDustSpriteData.LandingDust_SpriteName,
                    StaticRefs.movementDustSpriteData.LandingDust_SpriteInterval,
                    StaticRefs.movementDustSpriteData.LandingDust_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                landingDust.transform);

            return landingDust;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(DefineUnit());
        }
    }
}