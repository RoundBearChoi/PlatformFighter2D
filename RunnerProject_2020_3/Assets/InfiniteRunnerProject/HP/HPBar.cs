using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class HPBar : MonoBehaviour
    {
        Unit _ownerUnit = null;
        Vector2 _targetLocalPos = Vector2.zero;

        [SerializeField]
        SpriteRenderer red;

        public void SetOwnerUnit(Unit ownerUnit, Vector2 localPos)
        {
            _ownerUnit = ownerUnit;
            _targetLocalPos = localPos;
        }

        public void Update()
        {
            this.transform.position = new Vector3(_ownerUnit.transform.position.x + _targetLocalPos.x, _ownerUnit.transform.position.y + _targetLocalPos.y, _ownerUnit.transform.position.z);
        }

        public void UpdateRed()
        {

        }

        public void UpdateOrange()
        {

        }
    }
}