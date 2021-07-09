using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem_Creator : UnitCreator
    {
        private Transform _parentTransform;

        public Golem_Creator(Transform parentTransform)
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