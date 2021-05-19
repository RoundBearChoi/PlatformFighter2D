using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ObstaclePlacerCreator : UnitCreator
    {
        private Transform _parentTransform = null;
        private Unit _runner = null;

        public ObstaclePlacerCreator(Transform parentTransform, Unit runner)
        {
            _parentTransform = parentTransform;
            _runner = runner;
        }

        public override Unit GetUnit()
        {
            GameObject obj = new GameObject("ObstaclePlacer (Clone)");
            Unit placer = obj.AddComponent<ObstaclePlacer>();
            placer.stateController = new StateController(StateFactory.Create_ObstaclePlacer_Repeat(placer.unitData, _runner));
            placer.transform.parent = _parentTransform;
            placer.transform.localPosition = Vector3.zero;
            placer.transform.localRotation = Quaternion.identity;
            placer.SetUpdater(new DefaultFixedUpdater(placer.stateController));
            placer.transform.parent = _parentTransform;
            placer.transform.localPosition = Vector3.zero;
            placer.transform.localRotation = Quaternion.identity;

            placer.listSpriteAnimations = new List<SpriteAnimation>();

            return placer;
        }
    }
}