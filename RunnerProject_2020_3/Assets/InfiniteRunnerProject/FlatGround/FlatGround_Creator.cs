using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FlatGround_Creator : UnitCreator
    {
        private Transform _parentTransform;

        public FlatGround_Creator(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public override Unit GetUnit()
        {
            Unit flatGround = GameObject.Instantiate(ResourceLoader.GetResource(typeof(FlatGround))) as FlatGround;
            flatGround.unitData = new UnitData(flatGround.transform);

            flatGround.transform.parent = _parentTransform;
            flatGround.transform.localRotation = Quaternion.identity;
            flatGround.transform.localPosition = Vector3.zero;

            return flatGround;
        }
    }
}