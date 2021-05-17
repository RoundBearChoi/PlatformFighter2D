using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ObstacleCreator : UnitCreator
    {
        private Transform _parentTransform;

        public ObstacleCreator(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public override Unit GetUnit()
        {
            Unit obstacle = GameObject.Instantiate(ResourceLoader.Get(typeof(Obstacle))) as Obstacle;
            obstacle.SetParent(_parentTransform);
            obstacle.unitData = new UnitData(obstacle.transform);
            obstacle.stateController = new StateController(StateFactory.Create_Obstacle_Idle(obstacle.unitData));

            CollisionDetector obsCollider = GameObject.Instantiate(ResourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);
            obsCollider.InitBoxCollider(new Vector2(1f, 1f));
            obsCollider.transform.parent = obstacle.transform;
            obsCollider.transform.localRotation = Quaternion.identity;
            obsCollider.transform.localPosition = StaticRefs.gameData.ObstacleBoxColliderLocalPos;

            GameObject obstacleWhiteBox = GameObject.Instantiate(ResourceLoader.GetSprite(SpriteType.WHITE_BOX)) as GameObject;
            obstacle.AttachSprite(obstacleWhiteBox.GetComponent<UnitSprite>(), new Vector2(1f, 1f), OffsetType.BOTTOM_CENTER);

            return obstacle;
        }
    }
}