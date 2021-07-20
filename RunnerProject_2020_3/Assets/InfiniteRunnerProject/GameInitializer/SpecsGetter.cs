using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SpecsGetter
    {
        private List<BaseUnitCreationSpec> _listSpecs = null;

        public SpecsGetter(List<BaseUnitCreationSpec> listSpecs)
        {
            _listSpecs = listSpecs;
        }

        public List<BaseUnitCreationSpec> GetSpecs_BySpecType<T>()
        {
            List<BaseUnitCreationSpec> subList = new List<BaseUnitCreationSpec>();

            foreach (BaseUnitCreationSpec spec in _listSpecs)
            {
                if (spec is T)
                {
                    subList.Add(spec);
                }
            }

            return subList;
        }

        public List<BaseUnitCreationSpec> GetSpecs_ByUnitType(UnitType unitType)
        {
            List<BaseUnitCreationSpec> subList = new List<BaseUnitCreationSpec>();

            foreach (BaseUnitCreationSpec spec in _listSpecs)
            {
                if (spec.unitType == unitType)
                {
                    subList.Add(spec);
                }
            }

            return subList;
        }

        public BaseUnitCreationSpec GetSpec_BySpriteAnimationSpec(SpriteAnimationSpec spriteSpec)
        {
            foreach (BaseUnitCreationSpec creationSpec in _listSpecs)
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

        public BaseUnitCreationSpec GetSpec_ByUnitType(UnitType unitType)
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