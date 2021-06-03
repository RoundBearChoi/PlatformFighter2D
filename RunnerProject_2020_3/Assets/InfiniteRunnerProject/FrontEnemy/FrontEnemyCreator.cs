using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FrontEnemyCreator : UnitCreator
    {
        private Transform _parentTransform;

        public FrontEnemyCreator(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public override Unit GetUnit()
        {
            SampleLeftEnemy enemy = GameObject.Instantiate(ResourceLoader.GetResource(typeof(SampleLeftEnemy))) as SampleLeftEnemy;
            enemy.unitData = new UnitData(enemy.transform);

            enemy.stateController = new StateController(
                new FrontEnemy_Idle(enemy.unitData),
                enemy.unitData);
            enemy.transform.parent = _parentTransform;
            enemy.transform.localRotation = Quaternion.identity;
            enemy.SetUpdater(new DefaultFixedUpdater(enemy.stateController));

            enemy.InitSpriteAnimations();

            GameObject idleSprite = new GameObject("front enemy idle animation");
            idleSprite.transform.parent = enemy.transform;
            idleSprite.transform.localPosition = Vector3.zero;
            idleSprite.transform.localRotation = Quaternion.identity;
            enemy.spriteAnimations.Add(idleSprite.AddComponent<SpriteAnimation>());
            enemy.spriteAnimations.GetLastSpriteAnimation().Init(new SpriteAnimationSpecs(
                "Texture_Front_Enemy_Sample",
                10,
                new Vector2(2.33f, 2.57f),
                OffsetType.BOTTOM_CENTER));

            return enemy;
        }
    }
}