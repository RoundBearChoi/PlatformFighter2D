using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct OverlapBoxSpecs
    {
        public OverlapBoxSpecs(int targetSpriteIndex, int maxHits, uint stopFrames, Vector2 relativePoint, Vector2 size, float angle, ContactFilter2D contactFilter)
        {
            mRelativePoint = relativePoint;
            mMaxHits = maxHits;
            mStopFrames = stopFrames;
            mSize = size;
            mContactFilter2D = contactFilter;
            mAngle = angle;
            mTargetSpriteIndex = targetSpriteIndex;
        }

        public int mTargetSpriteIndex;
        public int mMaxHits;
        public uint mStopFrames;
        public Vector2 mRelativePoint;
        public Vector2 mSize;
        public float mAngle;
        public ContactFilter2D mContactFilter2D;
    }

    public class OverlapBoxCollision : StateComponent
    {
        List<OverlapBoxSpecs> _listSpecs;
        int _currentHitCount = 0;

        public OverlapBoxCollision(Unit unit, List<OverlapBoxSpecs> listSpecs)
        {
            _unit = unit;
            _listSpecs = listSpecs;
        }

        public override void OnFixedUpdate()
        {
            foreach(OverlapBoxSpecs specs in _listSpecs)
            {
                if (_unit.unitData.spriteAnimations.currentAnimation.SPRITE_INDEX == specs.mTargetSpriteIndex)
                {
                    Vector2 centerPoint = new Vector2(_unit.transform.position.x + specs.mRelativePoint.x, _unit.transform.position.y + specs.mRelativePoint.y);

                    List<Collider2D> results = BoxCalculator.GetCollisionResults(centerPoint, specs, 0.5f);

                    foreach(Collider2D col in results)
                    {
                        Unit collidingUnit = col.gameObject.GetComponent<Unit>();

                        //check against self, none, ground
                        if (collidingUnit.unitType != _unit.unitType && collidingUnit.unitType != UnitType.NONE && collidingUnit.unitType != UnitType.FLAT_GROUND)
                        {
                            _currentHitCount++;

                            if (_currentHitCount <= specs.mMaxHits)
                            {
                                Debugger.Log(_unit.name + " hit: " + col.gameObject.name + " (spriteindex: " + _unit.unitData.spriteAnimations.currentAnimation.SPRITE_INDEX + ")");

                                BaseMessage hitStopMessage = new HitStopMessage(specs.mStopFrames, _unit, MessageType.HITSTOP_REGISTER);
                                hitStopMessage.Register();
                            }
                            else
                            {
                                //Debugger.Log("collision detected but exeeded max hits");
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}