using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnitCreator
    {
        protected Transform _parentTransform = null;
        protected UnitCreationSpec _creationSpec = null;
        protected UnitState _firstState = null;

        public UnitCreator(Transform parentTransform, UnitCreationSpec creationSpec, UnitState firstState)
        {
            _parentTransform = parentTransform;
            _creationSpec = creationSpec;
            _firstState = firstState;
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
            unit.listNextStates.Clear();
            unit.SetOwnerStage(stage);
            unit.gameObject.layer = (int)LayerType.PHYSICAL_UNIT;

            unit.facingRight = _creationSpec.faceRight;
            unit.hp = _creationSpec.hp;
            unit.initialHP = _creationSpec.hp;
            unit.iStateController = new UnitStateController(unit);

            //_creationSpec.setInitialState.Invoke(unit);
            //_creationSpec.setUpdater.Invoke(unit);

            _firstState.SetOwnerUnit(unit);
            unit.iStateController.SetNewState(unit, _firstState);
            unit.unitUpdater = new DefaultUnitUpdater(unit);

            unit.InitBoxCollider(_creationSpec);
            unit.InitCollisionChecker();

            unit.spriteAnimations = new DefaultSpriteAnimations(unit.iStateController, unit);

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
                    GameObject sprObj = unit.spriteAnimations.AddSpriteAnimation(creationSpec, spriteSpec, unit.transform);

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