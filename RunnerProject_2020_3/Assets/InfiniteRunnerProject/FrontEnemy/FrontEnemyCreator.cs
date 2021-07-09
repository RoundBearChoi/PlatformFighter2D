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

        public override Unit DefineUnit()
        {
            Unit enemy = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.SAMPLE_LEFT_ENEMY)) as Unit;
            enemy.transform.parent = _parentTransform;
            enemy.transform.localRotation = Quaternion.identity;

            enemy.unitData = new UnitData(enemy.transform);
            enemy.attackData = new AttackData();

            enemy.iStateController = new StateController(
                new FrontEnemy_Idle(enemy),
                enemy.unitData);

            enemy.unitUpdater = new DefaultUpdater();
            enemy.unitUpdater.SetOwnerUnit(enemy);

            enemy.unitData.spriteAnimations = new SpriteAnimations(enemy.iStateController);

            enemy.unitData.spriteAnimations.AddSpriteAnimation("front enemy idle animation",
                new SpriteAnimationSpecs(
                    "Texture_Front_Enemy_Sample",
                    10,
                    new Vector2(2.33f, 2.57f),
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                enemy.transform);

            return enemy;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(DefineUnit());
        }
    }
}