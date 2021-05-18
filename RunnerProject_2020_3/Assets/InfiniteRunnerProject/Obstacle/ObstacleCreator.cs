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

            GameObject boxSprite = new GameObject("box sprite");
            boxSprite.transform.parent = obstacle.transform;
            boxSprite.transform.localPosition = Vector3.zero;
            boxSprite.transform.localRotation = Quaternion.identity;
            obstacle.listSpriteAnimations.Add(boxSprite.AddComponent<SpriteAnimation>());
            obstacle.listSpriteAnimations[obstacle.listSpriteAnimations.Count - 1].Init(new SpriteAnimationSpecs("Texture_White100x100", 10, new Vector2(1f, 1f), OffsetType.BOTTOM_CENTER));

            return obstacle;
        }
    }
}