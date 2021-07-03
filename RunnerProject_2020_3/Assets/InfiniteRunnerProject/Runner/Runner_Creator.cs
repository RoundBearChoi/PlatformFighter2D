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

            runner.stateController = new StateController(
                new Runner_Idle(runner.unitData, _userInput),
                runner.unitData);
            runner.transform.parent = _parentTransform;
            runner.transform.localRotation = Quaternion.identity;
            runner.SetUpdater(new DefaultUpdater(runner.stateController));

            runner.InitBoxCollider(StaticRefs.gameData.RunnerBoxColliderSize);
            runner.InitCollisionReaction();
            runner.InitCollisionChecker();
            runner.SetUserInput(_userInput);

            runner.unitData.spriteAnimations = new SpriteAnimations(runner.stateController);

            runner.unitData.spriteAnimations.AddSpriteAnimation("runner idle fall animation",
                new SpriteAnimationSpecs(
                    "Texture_PrototypeHero_Idle",
                    StaticRefs.runnerSpriteData.Idle_SpriteInterval,
                    StaticRefs.runnerSpriteData.Idle_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                runner.transform);
            AdditionalInterval idleinterval0 = new AdditionalInterval(140, 0);
            AdditionalInterval idleinterval3 = new AdditionalInterval(140, 3);
            runner.unitData.spriteAnimations.GetLastSpriteAnimation().AddAdditionalInterval(idleinterval0);
            runner.unitData.spriteAnimations.GetLastSpriteAnimation().AddAdditionalInterval(idleinterval3);

            runner.unitData.spriteAnimations.AddSpriteAnimation("runner run animation",
                new SpriteAnimationSpecs(
                    "Texture_RunCycle_Orange",
                    StaticRefs.runnerSpriteData.Run_SpriteInterval,
                    StaticRefs.runnerSpriteData.Run_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                runner.transform);

            runner.unitData.spriteAnimations.AddSpriteAnimation("runner straight punch animation",
                new SpriteAnimationSpecs(
                    "Texture_StraightPunch",
                    StaticRefs.runnerSpriteData.StraightPunch_SpriteInterval,
                    StaticRefs.runnerSpriteData.StraightPunch_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    StaticRefs.runnerSpriteData.StraightPunch_AdditionalOffset),
                runner.transform);
            runner.unitData.spriteAnimations.GetLastSpriteAnimation().playOnce = true;

            runner.unitData.spriteAnimations.AddSpriteAnimation("runner jump (up) animation",
                new SpriteAnimationSpecs(
                    "Texture_JumpCycle_Orange",
                    StaticRefs.runnerSpriteData.Jump_SpriteInterval,
                    StaticRefs.runnerSpriteData.Jump_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                runner.transform);
            runner.unitData.spriteAnimations.GetLastSpriteAnimation().playOnce = true;

            runner.unitData.spriteAnimations.AddSpriteAnimation("runner jump (fall) animation",
                new SpriteAnimationSpecs(
                    "Texture_Jump_Fall_Orange",
                    StaticRefs.runnerSpriteData.Jump_SpriteInterval,
                    StaticRefs.runnerSpriteData.Jump_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                runner.transform);
            runner.unitData.spriteAnimations.GetLastSpriteAnimation().playOnce = true;

            runner.unitData.spriteAnimations.AddSpriteAnimation("runner death animation",
                new SpriteAnimationSpecs(
                    "Texture_Death_Orange",
                    StaticRefs.runnerSpriteData.Death_SpriteInterval,
                    StaticRefs.runnerSpriteData.Death_SpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                runner.transform);
            runner.unitData.spriteAnimations.GetLastSpriteAnimation().playOnce = true;

            runner.transform.position = new Vector3(0f, 5f, 0f);

            return runner;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(GetUnit());
        }
    }
}