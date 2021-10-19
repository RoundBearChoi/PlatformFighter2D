using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnitCreator
    {
        protected Transform _parentTransform = null;
        protected UnitCreationSpec _creationSpec = null;

        public UnitCreator(Transform parentTransform, UnitCreationSpec creationSpec)
        {
            _parentTransform = parentTransform;
            _creationSpec = creationSpec;
        }

        public Unit InstantiateUnit(UnitCreationSpec creationSpec)
        {
            Unit unit = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(creationSpec.unitType)) as Unit;
            unit.unitType = creationSpec.unitType;
            unit.gameObject.name += (" - " + creationSpec.unitType.ToString());

            unit.transform.localRotation = creationSpec.localRotation;
            unit.transform.localPosition = creationSpec.localPosition;

            return unit;
        }

        public Unit DefineUnit(BaseStage stage)
        {
            Unit unit = InstantiateUnit(_creationSpec);
            unit.transform.SetParent(_parentTransform, false);
            unit.SetOwnerStage(stage);
            unit.gameObject.layer = (int)LayerType.PHYSICAL_UNIT;

            unit.unitData.facingRight = _creationSpec.faceRight;
            unit.unitData.hp = _creationSpec.hp;
            unit.unitData.initialHP = _creationSpec.hp;
            unit.iStateController = new UnitStateController(unit);

            _creationSpec.setInitialState.Invoke(unit);
            //_creationSpec.setUpdater.Invoke(unit);

            unit.unitUpdater = new DefaultUnitUpdater(unit);

            unit.InitBoxCollider(_creationSpec);
            unit.InitCollisionChecker();

            unit.unitData.spriteAnimations = new DefaultSpriteAnimations(unit.iStateController, unit);

            if (_creationSpec.listSpriteAnimationSpecs.Count > 0)
            {
                foreach (SpriteAnimationSpec spriteSpec in _creationSpec.listSpriteAnimationSpecs)
                {
                    SetSpriteAnimation(unit, _creationSpec, spriteSpec);
                }
            }

            return unit;
        }

        void SetSpriteAnimation(Unit unit, UnitCreationSpec creationSpec, SpriteAnimationSpec spriteSpec)
        {
            if (spriteSpec != null)
            {
                for (int i = 0; i < spriteSpec.additionalTiles + 1; i++)
                {
                    GameObject sprObj = unit.unitData.spriteAnimations.AddSpriteAnimation(creationSpec, spriteSpec, unit.transform);

                    float xTiling = 0f;

                    if (spriteSpec.offsetType == OffsetType.BOTTOM_LEFT ||
                        spriteSpec.offsetType == OffsetType.TOP_LEFT)
                    {
                        xTiling = sprObj.transform.localPosition.x * 2 * i;
                    }

                    sprObj.transform.localPosition = new Vector3(sprObj.transform.localPosition.x + xTiling, sprObj.transform.localPosition.y, sprObj.transform.localPosition.z);
                }
            }
        }
    }
}