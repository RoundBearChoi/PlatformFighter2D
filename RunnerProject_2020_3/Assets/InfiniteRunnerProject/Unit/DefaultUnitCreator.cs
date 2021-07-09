using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultUnitCreator : UnitCreator
    {
        public DefaultUnitCreator(UserInput userInput, Transform parentTransform, UnitCreationSpec creationSpec)
        {
            _userInput = userInput;
            _parentTransform = parentTransform;
            _creationSpec = creationSpec;
        }

        public override Unit DefineUnit()
        {
            Runner_NormalRun.initialPush = false;

            Unit unit = InstantiateUnit(_creationSpec);
            unit.transform.parent = _parentTransform;
            unit.iStateController = new StateController(unit);

            _creationSpec.setInitialState.Invoke(unit, _userInput);

            unit.unitUpdater = new DefaultUpdater();
            unit.unitUpdater.SetOwnerUnit(unit);

            unit.InitBoxCollider(_creationSpec);

            unit.InitCollisionChecker();

            if (_creationSpec.listSpriteAnimationSpecs.Count > 0)
            {
                unit.unitData.spriteAnimations = new SpriteAnimations(unit.iStateController);
            
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

                currentSpec = spec;
                spec.setCorrespondingState.Invoke();
            }
        }
    }
}