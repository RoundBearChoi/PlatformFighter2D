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
                runner.unitData,
                runner.listSpriteAnimations);
            runner.transform.parent = _parentTransform;
            runner.transform.localRotation = Quaternion.identity;
            runner.SetUpdater(new DefaultFixedUpdater(runner.stateController));

            runner.InitBoxCollider(StaticRefs.gameData.RunnerBoxColliderSize);
            runner.InitCollisionReaction();
            runner.InitCollisionChecker();
            runner.SetUserInput(_userInput);

            GameObject idleFallSprite = new GameObject("runner idle fall animation");
            idleFallSprite.transform.parent = runner.transform;
            idleFallSprite.transform.localPosition = Vector3.zero;
            idleFallSprite.transform.localRotation = Quaternion.identity;
            runner.listSpriteAnimations.Add(idleFallSprite.AddComponent<SpriteAnimation>());
            runner.listSpriteAnimations[runner.listSpriteAnimations.Count - 1].Init(new SpriteAnimationSpecs("Texture_Runner_IdleFall", 4, StaticRefs.gameData.Runner_Idle_SpriteSize, OffsetType.BOTTOM_CENTER));

            GameObject runSprite = new GameObject("runner run animation");
            runSprite.transform.parent = runner.transform;
            runSprite.transform.localPosition = Vector3.zero;
            runSprite.transform.localRotation = Quaternion.identity;
            runner.listSpriteAnimations.Add(runSprite.AddComponent<SpriteAnimation>());
            runner.listSpriteAnimations[runner.listSpriteAnimations.Count - 1].Init(new SpriteAnimationSpecs(
                "Texture_RunCycle_Orange",
                StaticRefs.gameData.Runner_Run_SpriteInterval,
                StaticRefs.gameData.Runner_Run_SpriteSize,
                OffsetType.BOTTOM_CENTER));

            GameObject jumpSprite = new GameObject("runner jump animation");
            jumpSprite.transform.parent = runner.transform;
            jumpSprite.transform.localPosition = Vector3.zero;
            jumpSprite.transform.localRotation = Quaternion.identity;
            runner.listSpriteAnimations.Add(jumpSprite.AddComponent<SpriteAnimation>());
            runner.listSpriteAnimations[runner.listSpriteAnimations.Count - 1].Init(new SpriteAnimationSpecs(
                "Texture_JumpCycle_Orange",
                StaticRefs.gameData.Runner_Jump_SpriteInterval,
                StaticRefs.gameData.Runner_Jump_SpriteSize,
                OffsetType.BOTTOM_CENTER));
            runner.listSpriteAnimations[runner.listSpriteAnimations.Count - 1].playOnce = true;

            GameObject deathSprite = new GameObject("runner death animation");
            deathSprite.transform.parent = runner.transform;
            deathSprite.transform.localPosition = Vector3.zero;
            deathSprite.transform.localRotation = Quaternion.identity;
            runner.listSpriteAnimations.Add(deathSprite.AddComponent<SpriteAnimation>());
            runner.listSpriteAnimations[runner.listSpriteAnimations.Count - 1].Init(new SpriteAnimationSpecs("Texture_SampleDeathAnimation", 10, StaticRefs.gameData.Runner_Death_SpriteSize, OffsetType.BOTTOM_CENTER));

            runner.transform.position = new Vector3(0f, 5f, 0f);

            return runner;
        }
    }
}