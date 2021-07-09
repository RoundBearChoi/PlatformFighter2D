using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Creator : UnitCreator
    {
        private UserInput _userInput;
        private Transform _parentTransform;

        public Runner_Creator(UserInput userInput, Transform parentTransform)
        {
            _userInput = userInput;
            _parentTransform = parentTransform;
        }

        public override Unit DefineUnit()
        {
            Runner_NormalRun.initialPush = false;

            Unit runner = InstantiateUnit(StaticRefs.runnerCreationSpec);
            runner.transform.parent = _parentTransform;

            runner.iStateController = new StateController(
                new Runner_Idle(runner, _userInput),
                runner.unitData);

            runner.unitUpdater = new DefaultUpdater();
            runner.unitUpdater.SetOwnerUnit(runner);

            runner.InitBoxCollider(StaticRefs.runnerCreationSpec);

            runner.InitCollisionChecker();

            if (StaticRefs.runnerCreationSpec.listSpriteAnimationSpecs.Count > 0)
            {
                runner.unitData.spriteAnimations = new SpriteAnimations(runner.iStateController);
            
                foreach(SpriteAnimationSpec spec in StaticRefs.runnerCreationSpec.listSpriteAnimationSpecs)
                {
                    SetSpriteAnimation(runner, spec);
                }
            }

            return runner;
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