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
            runner.InitSpriteAnimations();
            runner.SetUserInput(_userInput);

            runner.spriteAnimations.Add("runner idle fall animation",
                new SpriteAnimationSpecs(
                    "Texture_Idle_Orange",
                    StaticRefs.gameData.Runner_Idle_SpriteInterval,
                    StaticRefs.gameData.Runner_Idle_SpriteSize,
                    OffsetType.BOTTOM_CENTER),
                runner.transform);

            runner.spriteAnimations.Add("runner run animation",
                new SpriteAnimationSpecs(
                    "Texture_RunCycle_Orange",
                    StaticRefs.gameData.Runner_Run_SpriteInterval,
                    StaticRefs.gameData.Runner_Run_SpriteSize,
                    OffsetType.BOTTOM_CENTER),
                runner.transform);

            runner.spriteAnimations.Add("runner jump animation",
                new SpriteAnimationSpecs(
                    "Texture_JumpCycle_Orange",
                    StaticRefs.gameData.Runner_Jump_SpriteInterval,
                    StaticRefs.gameData.Runner_Jump_SpriteSize,
                    OffsetType.BOTTOM_CENTER),
                runner.transform);
            runner.spriteAnimations.GetLastSpriteAnimation().playOnce = true;

            runner.spriteAnimations.Add("runner death animation",
                new SpriteAnimationSpecs(
                    "Texture_Death_Orange",
                    StaticRefs.gameData.Runner_Death_SpriteInterval,
                    StaticRefs.gameData.Runner_Death_SpriteSize,
                    OffsetType.BOTTOM_CENTER),
                runner.transform);
            runner.spriteAnimations.GetLastSpriteAnimation().playOnce = true;

            runner.transform.position = new Vector3(0f, 5f, 0f);

            return runner;
        }
    }
}