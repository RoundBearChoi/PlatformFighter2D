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
            enemy.attackData = new AttackData();

            enemy.iStateController = new StateController(
                new FrontEnemy_Idle(enemy),
                enemy.unitData);
            enemy.transform.parent = _parentTransform;
            enemy.transform.localRotation = Quaternion.identity;
            enemy.SetUpdater(new DefaultUpdater(enemy.iStateController));

            enemy.unitData.spriteAnimations = new SpriteAnimations(enemy.iStateController);
            //enemy.InitSpriteAnimations();

            enemy.unitData.spriteAnimations.AddSpriteAnimation("front enemy idle animation",
                new SpriteAnimationSpecs(
                    "Texture_Front_Enemy_Sample",
                    new Vector2(2.33f, 2.57f),
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                enemy.transform);

            enemy.unitData.spriteAnimations.mStandardInterval = new StandardInterval(10);

            return enemy;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(GetUnit());
        }
    }
}