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

        public override Unit GetUnit()
        {
            Unit landingDust = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.LANDING_DUST)) as Unit;
            landingDust.unitData = new UnitData(landingDust.transform);

            landingDust.iStateController = new StateController(
                new LandingDust_DefaultState(landingDust),
                landingDust.unitData);
            landingDust.transform.parent = _parentTransform;
            landingDust.transform.localRotation = Quaternion.identity;
            //runner.SetUpdater(new DefaultUpdater(runner.iStateController));

            //runner.InitBoxCollider(StaticRefs.gameData.RunnerBoxColliderSize);
            //runner.InitCollisionReaction();
            //runner.InitCollisionChecker();
            //runner.SetUserInput(_userInput);

            landingDust.unitData.spriteAnimations = new SpriteAnimations(landingDust.iStateController);
            //runner.transform.position = new Vector3(0f, 5f, 0f);

            landingDust.unitData.spriteAnimations.AddSpriteAnimation(
                "landing dust animation",
                new SpriteAnimationSpecs(
                    "Texture_PrototypeHero_LandingDust",
                    5,
                    new Vector2(5, 5),
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                landingDust.transform);

            return landingDust;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(GetUnit());
        }
    }
}