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

        [SerializeField]
        SpriteRenderer orange;

        public void SetOwnerUnit(Unit ownerUnit, Vector2 localPos)
        {
            _ownerUnit = ownerUnit;
            _targetLocalPos = localPos;

            red.transform.localScale = new Vector3(1f, 1f, 1f);
            orange.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public void Update()
        {
            this.transform.position = new Vector3(_ownerUnit.transform.position.x + _targetLocalPos.x, _ownerUnit.transform.position.y + _targetLocalPos.y, _ownerUnit.transform.position.z);

            UpdateRed();
            UpdateOrange();
        }

        public void UpdateRed()
        {
            float percentage = (float)_ownerUnit.unitData.hp / (float)_ownerUnit.unitData.initialHP;
            red.transform.localScale = new Vector3(percentage, red.transform.localScale.y, 1f);
        }

        public void UpdateOrange()
        {
            orange.transform.localScale = Vector3.Lerp(orange.transform.localScale, new Vector3(red.transform.localScale.x, orange.transform.localScale.y, 1f), 0.65f * Time.deltaTime);
        }
    }
}