using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SwampBackground_Creator : UnitCreator
    {
        private Transform _parentTransform;

        public SwampBackground_Creator(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        Unit GetGrassUnit()
        {
            Unit swamp_grass = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.SWAMP_BACKGROUND)) as Unit;
            swamp_grass.unitData = new UnitData(swamp_grass.transform);

            swamp_grass.iStateController = new StateController(
                new Swamp_Grass_DefaultState(swamp_grass),
                swamp_grass.unitData);
            swamp_grass.transform.parent = _parentTransform;
            swamp_grass.transform.localRotation = Quaternion.identity;

            swamp_grass.unitData.spriteAnimations = new SpriteAnimations(swamp_grass.iStateController);

            swamp_grass.unitData.spriteAnimations.AddSpriteAnimation(
                "swamp background - grass",
                new SpriteAnimationSpecs(
                    StaticRefs.swampSpriteData.Swamp_Grass_SpriteName,
                    StaticRefs.swampSpriteData.Swamp_Unified_SpriteInterval,
                    StaticRefs.swampSpriteData.Swamp_Unified_SpriteSize,
                    OffsetType.BOTTOM_LEFT,
                    Vector2.zero),
                swamp_grass.transform);

            swamp_grass.transform.position = new Vector3(0f, 0f, -1f);

            return swamp_grass;
        }

        Unit GetRiverUnit()
        {
            Unit swamp_river = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.SWAMP_BACKGROUND)) as Unit;
            swamp_river.unitData = new UnitData(swamp_river.transform);

            swamp_river.iStateController = new StateController(
                new Swamp_River_DefaultState(swamp_river),
                swamp_river.unitData);
            swamp_river.transform.parent = _parentTransform;
            swamp_river.transform.localRotation = Quaternion.identity;

            swamp_river.unitData.spriteAnimations = new SpriteAnimations(swamp_river.iStateController);

            swamp_river.unitData.spriteAnimations.AddSpriteAnimation(
                "swamp background - river",
                new SpriteAnimationSpecs(
                    StaticRefs.swampSpriteData.Swamp_River_SpriteName,
                    StaticRefs.swampSpriteData.Swamp_Unified_SpriteInterval,
                    StaticRefs.swampSpriteData.Swamp_Unified_SpriteSize,
                    OffsetType.BOTTOM_LEFT,
                    Vector2.zero),
                swamp_river.transform);

            swamp_river.transform.position = new Vector3(0f, 0f, 2f);

            return swamp_river;
        }

        Unit GetFrontTreesUnit()
        {
            Unit swamp_frontTrees = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.SWAMP_BACKGROUND)) as Unit;
            swamp_frontTrees.unitData = new UnitData(swamp_frontTrees.transform);

            swamp_frontTrees.iStateController = new StateController(
                new Swamp_FrontTrees_DefaultState(swamp_frontTrees),
                swamp_frontTrees.unitData);
            swamp_frontTrees.transform.parent = _parentTransform;
            swamp_frontTrees.transform.localRotation = Quaternion.identity;

            swamp_frontTrees.unitData.spriteAnimations = new SpriteAnimations(swamp_frontTrees.iStateController);

            swamp_frontTrees.unitData.spriteAnimations.AddSpriteAnimation(
                "swamp background - front trees",
                new SpriteAnimationSpecs(
                    StaticRefs.swampSpriteData.Swamp_FrontTrees_SpriteName,
                    StaticRefs.swampSpriteData.Swamp_Unified_SpriteInterval,
                    StaticRefs.swampSpriteData.Swamp_Unified_SpriteSize,
                    OffsetType.BOTTOM_LEFT,
                    Vector2.zero),
                swamp_frontTrees.transform);

            swamp_frontTrees.transform.position = new Vector3(0f, 0f, 3f);

            return swamp_frontTrees;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(GetGrassUnit());
            listUnits.Add(GetRiverUnit());
            listUnits.Add(GetFrontTreesUnit());
        }
    }
}