using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultUnitCreator : BaseUnitCreator
    {
        public DefaultUnitCreator(Transform parentTransform, UnitCreationSpec creationSpec)
        {
            _parentTransform = parentTransform;
            _creationSpec = creationSpec;
        }

        public override Unit DefineUnit()
        {
            Unit unit = InstantiateUnit(_creationSpec);
            unit.transform.SetParent(_parentTransform, false);
            unit.gameObject.layer = (int)LayerType.PHYSICAL_UNIT;

            unit.unitData.facingRight = _creationSpec.faceRight;
            unit.unitData.hp = _creationSpec.hp;
            unit.unitData.initialHP = _creationSpec.hp;
            unit.iStateController = new UnitStateController(unit);

            _creationSpec.setInitialState.Invoke(unit);
            _creationSpec.setUpdater.Invoke(unit);

            unit.InitBoxCollider(_creationSpec);
            unit.InitCollisionChecker();

            unit.unitData.spriteAnimations = new DefaultSpriteAnimations(unit.iStateController, unit);

            if (_creationSpec.listSpriteAnimationSpecs.Count > 0)
            {
                foreach(SpriteAnimationSpec spriteSpec in _creationSpec.listSpriteAnimationSpecs)
                {
                    SetSpriteAnimation(unit, _creationSpec, spriteSpec);
                }
            }

            return unit;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(DefineUnit());
        }

        void SetSpriteAnimation(Unit unit, UnitCreationSpec creationSpec, SpriteAnimationSpec spriteSpec)
        {
            if (spriteSpec != null)
            {
                unit.unitData.spriteAnimations.AddSpriteAnimation(creationSpec, spriteSpec, unit.transform);
            }
        }
    }
}