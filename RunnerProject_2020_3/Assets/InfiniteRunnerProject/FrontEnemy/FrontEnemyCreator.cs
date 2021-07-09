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
            return null;
        }

        public override void AddUnits(List<Unit> listUnits)
        {

        }
    }
}