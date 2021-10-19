using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class InitialTextGUIMaterial : StateComponent
    {
        private Material _defaultMaterial = null;
        private uint _totalFrames = 0;

        public InitialTextGUIMaterial(UnitState unitState, uint totalFrames)
        {
            _unitState = unitState;
            _totalFrames = totalFrames;
        }

        public override void OnFixedUpdate()
        {
            if (_defaultMaterial == null)
            {
                _defaultMaterial = UNIT_DATA.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.sharedMaterial;
                UNIT_DATA.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.sharedMaterial = BaseInitializer.CURRENT.runnerDataSO.white_GUIText_material;
            }

            if (UNIT.iStateController.GetCurrentState().fixedUpdateCount > _totalFrames)
            {
                UNIT_DATA.spriteAnimations.GetCurrentAnimation().SPRITE_RENDERER.sharedMaterial = _defaultMaterial;
            }
        }
    }
}