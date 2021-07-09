using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_Creator : UnitCreator
    {
        private Transform _parentTransform;

        public Swamp_Creator(Transform parentTransform)
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