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

        public override Unit GetUnit()
        {
            //temp (probably should be put somewhere else..)
            Runner_NormalRun.initialPush = false;

            Unit runner = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.RUNNER)) as Unit;
            runner.unitData = new UnitData(runner.transform);

            runner.iStateController = new StateController(
                new Runner_Idle(runner, _userInput),
                runner.unitData);
            runner.transform.parent = _parentTransform;
            runner.transform.localRotation = Quaternion.identity;
            runner.SetUpdater(new DefaultUpdater(runner.iStateController));

            runner.InitBoxCollider(StaticRefs.gameData.RunnerBoxColliderSize);
            runner.InitCollisionReaction();
            runner.InitCollisionChecker();
            runner.SetUserInput(_userInput);

            runner.unitData.spriteAnimations = new SpriteAnimations(runner.iStateController);
            runner.transform.position = new Vector3(0f, 5f, 0f);

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
            listUnits.Add(GetUnit());
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
                "runner straight punch animation",
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