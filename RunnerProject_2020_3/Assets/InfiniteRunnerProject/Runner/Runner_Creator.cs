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

            runner.SetUpdater(new DefaultUpdater(runner.iStateController));

            runner.InitBoxCollider(StaticRefs.runnerMovementSpriteData.RunnerBoxColliderSize);
            runner.InitCollisionChecker();
            runner.SetUserInput(_userInput);

            runner.unitData.spriteAnimations = new SpriteAnimations(runner.iStateController);

            SetIdle(runner);
            SetRun(runner);
            SetAttackA(runner);
            SetJump_Up(runner);
            SetJump_Fall(runner);
            SetDeath(runner);

            return runner;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(DefineUnit());
        }

        void SetIdle(Unit unit)
        {
            unit.unitData.spriteAnimations.AddSpriteAnimation(
                "runner idle fall animation",
                new SpriteAnimationSpecs(
                    StaticRefs.runnerMovementSpriteData.Idle_SpriteName,
                    StaticRefs.runnerMovementSpriteData.Idle_SpriteInterval,
                    StaticRefs.runnerMovementSpriteData.Idle_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                unit.transform);

            foreach (AdditionalInterval additionalInterval in StaticRefs.runnerMovementSpriteData.Idle_AdditionalIntervals)
            {
                unit.unitData.spriteAnimations.GetLastSpriteAnimation().AddAdditionalInterval(additionalInterval);
            }
        }

        void SetRun(Unit unit)
        {
            unit.unitData.spriteAnimations.AddSpriteAnimation(
                "runner run animation",
                new SpriteAnimationSpecs(
                    StaticRefs.runnerMovementSpriteData.Run_SpriteName,
                    StaticRefs.runnerMovementSpriteData.Run_SpriteInterval,
                    StaticRefs.runnerMovementSpriteData.Run_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                unit.transform);
        }

        void SetAttackA(Unit unit)
        {
            unit.unitData.spriteAnimations.AddSpriteAnimation(
                "runner attack A animation",
                new SpriteAnimationSpecs(
                    StaticRefs.runnerAttackSpriteData.AttackA_SpriteName,
                    StaticRefs.runnerAttackSpriteData.AttackA_SpriteInterval,
                    StaticRefs.runnerAttackSpriteData.AttackA_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    StaticRefs.runnerAttackSpriteData.AttackA_AdditionalOffset),
                unit.transform);

            unit.unitData.spriteAnimations.GetLastSpriteAnimation().playOnce = true;
        }

        void SetJump_Up(Unit unit)
        {
            unit.unitData.spriteAnimations.AddSpriteAnimation(
                "runner jump (up) animation",
                new SpriteAnimationSpecs(
                    StaticRefs.runnerMovementSpriteData.Jump_SpriteName,
                    StaticRefs.runnerMovementSpriteData.Jump_SpriteInterval,
                    StaticRefs.runnerMovementSpriteData.Jump_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                unit.transform);

            unit.unitData.spriteAnimations.GetLastSpriteAnimation().playOnce = true;
        }

        void SetJump_Fall(Unit unit)
        {
            unit.unitData.spriteAnimations.AddSpriteAnimation(
                "runner jump (fall) animation",
                new SpriteAnimationSpecs(
                    "Texture_Jump_Fall_Orange",
                    StaticRefs.runnerMovementSpriteData.Jump_SpriteInterval,
                    StaticRefs.runnerMovementSpriteData.Jump_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                unit.transform);

            unit.unitData.spriteAnimations.GetLastSpriteAnimation().playOnce = true;
        }

        void SetDeath(Unit unit)
        {
            unit.unitData.spriteAnimations.AddSpriteAnimation(
                "runner death animation",
                new SpriteAnimationSpecs(
                    StaticRefs.runnerMovementSpriteData.Death_SpriteName,
                    StaticRefs.runnerMovementSpriteData.Death_SpriteInterval,
                    StaticRefs.runnerMovementSpriteData.Death_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                unit.transform);

            unit.unitData.spriteAnimations.GetLastSpriteAnimation().playOnce = true;
        }
    }
}