using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpecsGetter
    {
        private List<DefaultUnitCreationSpec> _listSpecs = null;

        public SpecsGetter(List<DefaultUnitCreationSpec> listSpecs)
        {
            _listSpecs = listSpecs;
        }

        public List<DefaultUnitCreationSpec> GetSpecs_BySpecType<T>()
        {
            List<DefaultUnitCreationSpec> subList = new List<DefaultUnitCreationSpec>();

            foreach (DefaultUnitCreationSpec spec in _listSpecs)
            {
                if (spec is T)
                {
                    subList.Add(spec);
                }
            }

            return subList;
        }

        public List<DefaultUnitCreationSpec> GetSpecs_ByUnitType(UnitType unitType)
        {
            List<DefaultUnitCreationSpec> subList = new List<DefaultUnitCreationSpec>();

            foreach (DefaultUnitCreationSpec spec in _listSpecs)
            {
                if (spec.unitType == unitType)
                {
                    subList.Add(spec);
                }
            }

            return subList;
        }

        public DefaultUnitCreationSpec GetSpec_BySpriteAnimationSpec(SpriteAnimationSpec spriteSpec)
        {
            foreach (DefaultUnitCreationSpec creationSpec in _listSpecs)
            {
                foreach(SpriteAnimationSpec s in creationSpec.listSpriteAnimationSpecs)
                {
                    if (s == spriteSpec)
                    {
                        return creationSpec;
                    }
                }
            }

            return null;
        }

        public DefaultUnitCreationSpec GetSpec_ByUnitType(UnitType unitType)
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