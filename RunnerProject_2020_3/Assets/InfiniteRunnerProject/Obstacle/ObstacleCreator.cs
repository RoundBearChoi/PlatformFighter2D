using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ObstacleCreator : UnitCreator
    {
        private Transform _parentTransform;
        private Unit _runner;

        public ObstacleCreator(Transform parentTransform, Unit runner)
        {
            _parentTransform = parentTransform;
            _runner = runner;
        }

        public override Unit GetUnit()
        {
            Unit obstacle = GameObject.Instantiate(ResourceLoader.GetResource(typeof(Obstacle))) as Obstacle;
            obstacle.unitData = new UnitData(obstacle.transform);
            obstacle.iStateController = new StateController(
                new Obstacle_Idle(obstacle, _runner),
                obstacle.unitData);
            obstacle.transform.parent = _parentTransform;
            obstacle.transform.position = Vector3.zero;
            obstacle.transform.rotation = Quaternion.identity;
            obstacle.SetUpdater(new DefaultUpdater(obstacle.iStateController));

            obstacle.unitData.spriteAnimations.AddSpriteAnimation("box sprite",
                new SpriteAnimationSpecs(
                    "Texture_BlockEnemy",
                    StaticRefs.gameData.ObstacleSpriteSize,
                    OffsetType.BOTTOM_CENTER,
                    Vector2.zero),
                obstacle.transform);

            obstacle.unitData.spriteAnimations.mStandardInterval = new StandardInterval(10);

            //set initial obstacle position in relation to the runner
            obstacle.transform.position = new Vector3(_runner.transform.position.x + 10f, 0f, 0f);

            return obstacle;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(GetUnit());
        }
    }
}