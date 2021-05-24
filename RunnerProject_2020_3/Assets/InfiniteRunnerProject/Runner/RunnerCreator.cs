using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerCreator : UnitCreator
    {
        private UserInput _userInput;
        private Transform _parentTransform;

        public RunnerCreator(UserInput userInput, Transform parentTransform)
        {
            _userInput = userInput;
            _parentTransform = parentTransform;
        }

        public override Unit GetUnit()
        {
            Unit runner = GameObject.Instantiate(ResourceLoader.Get(typeof(Runner))) as Runner;
            runner.unitData = new UnitData(runner.transform);
            runner.stateController = new StateController(new Runner_Idle(runner.unitData, _userInput));
            runner.transform.parent = _parentTransform;
            runner.transform.localPosition = Vector3.zero;
            runner.transform.localRotation = Quaternion.identity;
            runner.SetUpdater(new DefaultFixedUpdater(runner.stateController));

            GameObject detectorObj = new GameObject("CollisionDetector (Clone)");
            CollisionDetector col = detectorObj.AddComponent<CollisionDetector>();
            col.InitBoxCollider(StaticRefs.gameData.RunnerBoxColliderSize);
            col.transform.parent = runner.transform;
            col.transform.localRotation = Quaternion.identity;
            col.transform.localPosition = StaticRefs.gameData.RunnerBoxColliderLocalPos;
            runner.collisionDetector = col;

            GameObject runSprite = new GameObject("runner sprite animation");
            runSprite.transform.parent = runner.transform;
            runSprite.transform.localPosition = Vector3.zero;
            runSprite.transform.localRotation = Quaternion.identity;
            runner.listSpriteAnimations.Add(runSprite.AddComponent<SpriteAnimation>());
            runner.listSpriteAnimations[runner.listSpriteAnimations.Count - 1].Init(new SpriteAnimationSpecs("Texture_RunCycle", 4, StaticRefs.gameData.RunnerSpriteSize, OffsetType.BOTTOM_CENTER));

            GameObject deathSprite = new GameObject("runner death animation");
            deathSprite.transform.parent = runner.transform;
            deathSprite.transform.localPosition = Vector3.zero;
            deathSprite.transform.localRotation = Quaternion.identity;
            runner.listSpriteAnimations.Add(deathSprite.AddComponent<SpriteAnimation>());
            runner.listSpriteAnimations[runner.listSpriteAnimations.Count - 1].Init(new SpriteAnimationSpecs("Texture_SampleDeathAnimation", 10, new Vector2(2f, 3f), OffsetType.BOTTOM_CENTER));

            return runner;
        }
    }
}