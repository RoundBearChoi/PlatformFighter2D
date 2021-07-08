using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Swamp_Creator : UnitCreator
    {
        private Transform _parentTransform;

        public Swamp_Creator(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        Unit GetGrassUnit()
        {
            Unit swamp_grass = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.SWAMP)) as Unit;
            swamp_grass.transform.parent = _parentTransform;
            swamp_grass.transform.localRotation = Quaternion.identity;
            swamp_grass.transform.position = StaticRefs.swampSpriteData.Swamp_Grass_StartPos;

            swamp_grass.unitData = new UnitData(swamp_grass.transform);
            
            swamp_grass.iStateController = new StateController(
                new Swamp_Grass_DefaultState(swamp_grass),
                swamp_grass.unitData);

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

            return swamp_grass;
        }

        Unit GetRiverUnit()
        {
            Unit swamp_river = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.SWAMP)) as Unit;
            swamp_river.unitData = new UnitData(swamp_river.transform);

            swamp_river.transform.position = StaticRefs.swampSpriteData.Swamp_River_StartPos;

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

            return swamp_river;
        }

        Unit GetFrontTreesUnit()
        {
            Unit swamp_frontTrees = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.SWAMP)) as Unit;
            swamp_frontTrees.unitData = new UnitData(swamp_frontTrees.transform);

            swamp_frontTrees.transform.position = StaticRefs.swampSpriteData.Swamp_FrontTrees_StartPos;

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

            return swamp_frontTrees;
        }

        Unit GetBackTreesUnit()
        {
            Unit swamp_backTrees = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.SWAMP)) as Unit;
            swamp_backTrees.unitData = new UnitData(swamp_backTrees.transform);

            swamp_backTrees.transform.position = StaticRefs.swampSpriteData.Swamp_BackTrees_StartPos;

            swamp_backTrees.iStateController = new StateController(
                new Swamp_BackTrees_DefaultState(swamp_backTrees),
                swamp_backTrees.unitData);
            swamp_backTrees.transform.parent = _parentTransform;
            swamp_backTrees.transform.localRotation = Quaternion.identity;

            swamp_backTrees.unitData.spriteAnimations = new SpriteAnimations(swamp_backTrees.iStateController);

            swamp_backTrees.unitData.spriteAnimations.AddSpriteAnimation(
                "swamp background - back trees",
                new SpriteAnimationSpecs(
                    StaticRefs.swampSpriteData.Swamp_BackTrees_SpriteName,
                    StaticRefs.swampSpriteData.Swamp_Unified_SpriteInterval,
                    StaticRefs.swampSpriteData.Swamp_Unified_SpriteSize,
                    OffsetType.BOTTOM_LEFT,
                    Vector2.zero),
                swamp_backTrees.transform);

            return swamp_backTrees;
        }

        Unit GetBackgroundColorUnit()
        {
            Unit swamp_backgroundColor = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.SWAMP)) as Unit;
            swamp_backgroundColor.unitData = new UnitData(swamp_backgroundColor.transform);

            swamp_backgroundColor.transform.position = StaticRefs.swampSpriteData.Swamp_BackgroundColor_StartPos;

            swamp_backgroundColor.iStateController = new StateController(
                new Swamp_BackgroundColor_DefaultState(swamp_backgroundColor),
                swamp_backgroundColor.unitData);
            swamp_backgroundColor.transform.parent = _parentTransform;
            swamp_backgroundColor.transform.localRotation = Quaternion.identity;

            swamp_backgroundColor.unitData.spriteAnimations = new SpriteAnimations(swamp_backgroundColor.iStateController);

            swamp_backgroundColor.unitData.spriteAnimations.AddSpriteAnimation(
                "swamp background - background color",
                new SpriteAnimationSpecs(
                    StaticRefs.swampSpriteData.Swamp_BackgroundColor_SpriteName,
                    StaticRefs.swampSpriteData.Swamp_Unified_SpriteInterval,
                    StaticRefs.swampSpriteData.Swamp_Unified_SpriteSize,
                    OffsetType.BOTTOM_LEFT,
                    Vector2.zero),
                swamp_backgroundColor.transform);

            return swamp_backgroundColor;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(GetGrassUnit());
            listUnits.Add(GetRiverUnit());
            listUnits.Add(GetFrontTreesUnit());
            listUnits.Add(GetBackTreesUnit());

            //don't need background color as texture
            //listUnits.Add(GetBackgroundColorUnit());
        }
    }
}