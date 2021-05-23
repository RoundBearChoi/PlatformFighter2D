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
            Unit obstacle = GameObject.Instantiate(ResourceLoader.Get(typeof(Obstacle))) as Obstacle;
            obstacle.unitData = new UnitData(obstacle.transform);
            obstacle.stateController = new StateController(new Obstacle_Idle(obstacle.unitData, _runner));
            obstacle.transform.parent = _parentTransform;
            obstacle.transform.position = Vector3.zero;
            obstacle.transform.rotation = Quaternion.identity;
            obstacle.SetUpdater(new DefaultFixedUpdater(obstacle.stateController));

            GameObject detectorObj = new GameObject("CollisionDetector (Clone)");
            CollisionDetector col = detectorObj.AddComponent<CollisionDetector>();
            col.InitBoxCollider(new Vector2(1f, 1f));
            col.transform.parent = obstacle.transform;
            col.transform.localRotation = Quaternion.identity;
            col.transform.localPosition = StaticRefs.gameData.ObstacleBoxColliderLocalPos;

            GameObject boxSprite = new GameObject("box sprite");
            boxSprite.transform.parent = obstacle.transform;
            boxSprite.transform.localPosition = Vector3.zero;
            boxSprite.transform.localRotation = Quaternion.identity;
            obstacle.listSpriteAnimations.Add(boxSprite.AddComponent<SpriteAnimation>());
            obstacle.listSpriteAnimations[obstacle.listSpriteAnimations.Count - 1].Init(new SpriteAnimationSpecs("Texture_White100x100", 10, new Vector2(1f, 1f), OffsetType.BOTTOM_CENTER));

            //set initial obstacle position in relation to the runner
            obstacle.transform.position = new Vector3(_runner.transform.position.x + 10f, 0f, 0f);

            return obstacle;
        }
    }
}