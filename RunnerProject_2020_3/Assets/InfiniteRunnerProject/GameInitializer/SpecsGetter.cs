using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpecsGetter
    {
        private List<UnitCreationSpec> _listSpecs = null;

        public SpecsGetter(List<UnitCreationSpec> listSpecs)
        {
            _listSpecs = listSpecs;
        }

        public List<UnitCreationSpec> GetSpecs_BySpecType<T>()
        {
            List<UnitCreationSpec> subList = new List<UnitCreationSpec>();

            foreach (UnitCreationSpec spec in _listSpecs)
            {
                if (spec is T)
                {
                    subList.Add(spec);
                }
            }

            return subList;
        }

        public List<UnitCreationSpec> GetSpecs_ByUnitType(UnitType unitType)
        {
            List<UnitCreationSpec> subList = new List<UnitCreationSpec>();

            foreach (UnitCreationSpec spec in _listSpecs)
            {
                if (spec.unitType == unitType)
                {
                    subList.Add(spec);
                }
            }

            return subList;
        }

        public UnitCreationSpec GetSpec_BySpriteType(SpriteType spriteType)
        {
            foreach (UnitCreationSpec creationSpec in _listSpecs)
            {
                foreach (SpriteAnimationSpec s in creationSpec.listSpriteAnimationSpecs)
                {
                    if (s.spriteType == spriteType)
                    {
                        return creationSpec;
                    }
                }
            }

            return null;
        }

        public UnitCreationSpec GetSpec_ByUnitType(UnitType unitType)
        {
            for (int i = _listSpecs.Count - 1; i >= 0; i--)
            {
                if (_listSpecs[i].unitType == unitType)
                {
                    return _listSpecs[i];
                }
            }

            return null;
        }
    }
}