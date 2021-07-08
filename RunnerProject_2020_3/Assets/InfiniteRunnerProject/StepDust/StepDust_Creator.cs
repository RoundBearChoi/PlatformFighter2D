using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StepDust_Creator : UnitCreator
    {
        private Transform _parentTransform;

        public StepDust_Creator(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public override Unit DefineUnit()
        {
            Unit stepDust = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.STEP_DUST)) as Unit;
            stepDust.transform.parent = _parentTransform;
            stepDust.transform.localRotation = Quaternion.identity;

            stepDust.unitData = new UnitData(stepDust.transform);

            stepDust.iStateController = new StateController(
                new StepDust_DefaultState(stepDust),
                stepDust.unitData);

            stepDust.unitData.spriteAnimations = new SpriteAnimations(stepDust.iStateController);

            stepDust.unitData.spriteAnimations.AddSpriteAnimation(
                "step dust animation",
                new SpriteAnimationSpecs(
                    StaticRefs.movementDustSpriteData.StepDust_SpriteName,
                    StaticRefs.movementDustSpriteData.StepDust_SpriteInterval,
                    StaticRefs.movementDustSpriteData.StepDust_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                stepDust.transform);

            return stepDust;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(DefineUnit());
        }
    }
}