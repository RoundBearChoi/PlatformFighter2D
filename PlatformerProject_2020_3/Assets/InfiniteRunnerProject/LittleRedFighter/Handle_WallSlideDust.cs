using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Handle_WallSlideDust : IHandleMessage
    {
        Vector3 _dustPosition = Vector3.zero;
        bool _faceRight = true;

        public Handle_WallSlideDust(Vector3 dustPosition, bool faceRight)
        {
            _dustPosition = dustPosition;
            _faceRight = faceRight;
        }

        public bool Handle()
        {
            BaseInitializer.CURRENT.STAGE.InstantiateUnit_ByUnitType(UnitType.WALLSLIDE_DUST, new WallSlideDust_DefaultState());
            Unit wallSlideDust = Units.instance.GetUnit<WallSlideDust>();

            wallSlideDust.transform.position = _dustPosition;
            wallSlideDust.facingRight = _faceRight;

            return true;
        }
    }
}