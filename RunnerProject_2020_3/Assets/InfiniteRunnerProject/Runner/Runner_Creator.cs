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

            Unit runner = GameObject.Instantiate(ResourceLoader.GetResource(typeof(Runner))) as Runner;
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
                    "Texture_PrototypeHero_Idle",
                    StaticRefs.runnerSpriteData.Idle_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                unit.transform);

            unit.unitData.spriteAnimations.mStandardInterval = new StandardIntervalCounter(StaticRefs.runnerSpriteData.Idle_SpriteInterval);

            //foreach (AdditionalInterval additionalInterval in StaticRefs.runnerSpriteData.Idle_AdditionalIntervals)
            //{
            //    unit.unitData.spriteAnimations.GetLastSpriteAnimation().AddAdditionalInterval(additionalInterval);
            //}
        }

        void SetRun(Unit unit)
        {
            unit.unitData.spriteAnimations.AddSpriteAnimation(
                "runner run animation",
                new SpriteAnimationSpecs(
                    "Texture_RunCycle_Orange",
                    StaticRefs.runnerSpriteData.Run_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                unit.transform);

            unit.unitData.spriteAnimations.mStandardInterval = new StandardIntervalCounter(StaticRefs.runnerSpriteData.Run_SpriteInterval);
        }

        void SetAttackA(Unit unit)
        {
            unit.unitData.spriteAnimations.AddSpriteAnimation(
                "runner straight punch animation",
                new SpriteAnimationSpecs(
                    "Texture_StraightPunch",
                    StaticRefs.runnerSpriteData.StraightPunch_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    StaticRefs.runnerSpriteData.StraightPunch_AdditionalOffset),
                unit.transform);

            unit.unitData.spriteAnimations.mStandardInterval = new StandardIntervalCounter(StaticRefs.runnerSpriteData.StraightPunch_SpriteInterval);
            unit.unitData.spriteAnimations.GetLastSpriteAnimation().playOnce = true;
        }

        void SetJump_Up(Unit unit)
        {
            unit.unitData.spriteAnimations.AddSpriteAnimation(
                "runner jump (up) animation",
                new SpriteAnimationSpecs(
                    "Texture_JumpCycle_Orange",
                    StaticRefs.runnerSpriteData.Jump_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                unit.transform);

            unit.unitData.spriteAnimations.mStandardInterval = new StandardIntervalCounter(StaticRefs.runnerSpriteData.Jump_SpriteInterval);
            unit.unitData.spriteAnimations.GetLastSpriteAnimation().playOnce = true;
        }

        void SetJump_Fall(Unit unit)
        {
            unit.unitData.spriteAnimations.AddSpriteAnimation(
                "runner jump (fall) animation",
                new SpriteAnimationSpecs(
                    "Texture_Jump_Fall_Orange",
                    StaticRefs.runnerSpriteData.Jump_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                unit.transform);

            unit.unitData.spriteAnimations.mStandardInterval = new StandardIntervalCounter(StaticRefs.runnerSpriteData.Jump_SpriteInterval);
            unit.unitData.spriteAnimations.GetLastSpriteAnimation().playOnce = true;
        }

        void SetDeath(Unit unit)
        {
            unit.unitData.spriteAnimations.AddSpriteAnimation(
                "runner death animation",
                new SpriteAnimationSpecs(
                    "Texture_Death_Orange",
                    StaticRefs.runnerSpriteData.Death_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                unit.transform);

            unit.unitData.spriteAnimations.mStandardInterval = new StandardIntervalCounter(StaticRefs.runnerSpriteData.Death_SpriteInterval);
            unit.unitData.spriteAnimations.GetLastSpriteAnimation().playOnce = true;
        }
    }
}