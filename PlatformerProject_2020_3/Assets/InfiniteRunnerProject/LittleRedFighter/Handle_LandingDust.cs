using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Handle_LandingDust : IHandleMessage
    {
        Vector3 _dustPosition = Vector3.zero;
        Vector2 _scaleMultiplier = new Vector3(1f, 1f);
        bool _faceRight = true;

        public Handle_LandingDust(Vector3 dustPosition, Vector2 scaleMultiplier, bool faceRight)
        {
            _dustPosition = dustPosition;
            _scaleMultiplier = scaleMultiplier;
            _faceRight = faceRight;
        }

        public bool Handle()
        {
            BaseInitializer.CURRENT.STAGE.InstantiateUnit_ByUnitType(UnitType.LANDING_DUST, new LandingDust_DefaultState());
            Unit landingDust = Units.instance.GetUnit<LandingDust>();

            landingDust.transform.position = _dustPosition;

            //set custom scale
            SpriteAnimation spr = landingDust.unitData.spriteAnimations.GetLastSpriteAnimation();
            float x = spr.gameObject.transform.localScale.x * _scaleMultiplier.x;
            float y = spr.gameObject.transform.localScale.y * _scaleMultiplier.y;
            spr.gameObject.transform.localScale = new Vector3(x, y, spr.gameObject.transform.localScale.z);
            spr.SetLocalPositionOnOffset();

            return true;
        }
    }
}