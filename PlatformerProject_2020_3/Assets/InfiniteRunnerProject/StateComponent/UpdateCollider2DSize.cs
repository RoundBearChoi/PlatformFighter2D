using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UpdateCollider2DSize : StateComponent
    {
        Vector2 _targetSize = Vector2.zero;

        public UpdateCollider2DSize(UnitState unitState, Vector2 targetSize)
        {
            _unitState = unitState;
            _targetSize = targetSize;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT_DATA.boxCollider2D != null)
            {
                float sq = Vector2.SqrMagnitude(UNIT_DATA.boxCollider2D.size - _targetSize);

                if (sq > 0.0001f)
                {
                    UNIT_DATA.boxCollider2D.size = Vector2.Lerp(UNIT_DATA.boxCollider2D.size, _targetSize, 0.3f);
                    UNIT_DATA.boxCollider2D.offset = new Vector2(0f, UNIT_DATA.boxCollider2D.size.y / 2f);
                    //Debugger.Log("target size: " + _targetSize + "  current size: " + _unit.unitData.boxCollider2D.size + "  sqmag: " + sq);
                }
            }
        }
    }
}