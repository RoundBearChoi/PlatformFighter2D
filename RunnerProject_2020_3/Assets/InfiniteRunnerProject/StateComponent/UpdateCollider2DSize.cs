using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UpdateCollider2DSize : StateComponent
    {
        Vector2 _targetSize = Vector2.zero;

        public UpdateCollider2DSize(Unit unit, Vector2 targetSize)
        {
            _unit = unit;
            _targetSize = targetSize;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.boxCollider2D != null)
            {
                float sq = Vector2.SqrMagnitude(_unit.unitData.boxCollider2D.size - _targetSize);

                if (sq > 0.0001f)
                {
                    _unit.unitData.boxCollider2D.size = Vector2.Lerp(_unit.unitData.boxCollider2D.size, _targetSize, 0.3f);
                    _unit.unitData.boxCollider2D.offset = new Vector2(0f, _unit.unitData.boxCollider2D.size.y / 2f);
                    Debugger.Log("target size: " + _targetSize + "  current size: " + _unit.unitData.boxCollider2D.size + "  sqmag: " + sq);
                }
            }
        }
    }
}