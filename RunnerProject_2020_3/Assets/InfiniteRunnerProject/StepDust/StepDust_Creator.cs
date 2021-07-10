using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StepDust_Creator : BaseUnitCreator
    {
        public StepDust_Creator(Transform parentTransform)
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