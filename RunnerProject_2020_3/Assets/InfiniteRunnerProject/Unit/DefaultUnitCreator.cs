using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultUnitCreator : BaseUnitCreator
    {
        public DefaultUnitCreator(UserInput userInput, Transform parentTransform, BaseUnitCreationSpec creationSpec)
        {
            _userInput = userInput;
            _parentTransform = parentTransform;
            _creationSpec = creationSpec;
        }

        public override Unit DefineUnit()
        {
            Unit unit = InstantiateUnit(_creationSpec);
            unit.transform.parent = _parentTransform;

            unit.unitData = new UnitData(unit.transform);
            unit.unitData.faceRight = _creationSpec.faceRight;
            unit.iStateController = new StateController(unit);

            _creationSpec.setInitialState.Invoke(unit, _userInput);
            _creationSpec.setUpdater.Invoke(unit);

            unit.InitBoxCollider(_creationSpec);
            unit.InitCollisionChecker();

            unit.unitData.spriteAnimations = new SpriteAnimations(unit.iStateController);

            if (_creationSpec.listSpriteAnimationSpecs.Count > 0)
            {
                foreach(SpriteAnimationSpec spec in _creationSpec.listSpriteAnimationSpecs)
                {
                    SetSpriteAnimation(unit, spec);
                }
            }

            return unit;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(DefineUnit());
        }

        void SetSpriteAnimation(Unit unit, SpriteAnimationSpec spec)
        {
            if (spec != null)
            {
                unit.unitData.spriteAnimations.AddSpriteAnimation(spec, unit.transform);

                foreach (AdditionalInterval additionalInterval in spec.additionalIntervals)
                {
                    unit.unitData.spriteAnimations.GetLastSpriteAnimation().AddAdditionalInterval(additionalInterval);
                }

                spec.setCorrespondingState.Invoke(spec);
            }
        }
    }
}