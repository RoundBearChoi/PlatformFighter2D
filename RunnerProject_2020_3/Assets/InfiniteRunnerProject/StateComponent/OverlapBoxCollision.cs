using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct OverlapBoxSpecs
    {
        public OverlapBoxSpecs(int targetSpriteIndex, int maxHits, Vector2 relativePoint, Vector2 size, float angle, ContactFilter2D contactFilter)
        {
            mRelativePoint = relativePoint;
            mMaxHits = maxHits;
            mSize = size;
            mContactFilter2D = contactFilter;
            mAngle = angle;
            mTargetSpriteIndex = targetSpriteIndex;
        }

        public int mTargetSpriteIndex;
        public int mMaxHits;
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

        public override void Update()
        {
            foreach(OverlapBoxSpecs specs in _listSpecs)
            {
                if (_unit.unitData.spriteAnimations.currentAnimation.SPRITE_INDEX == specs.mTargetSpriteIndex)
                {
                    Vector2 centerPoint = new Vector2(_unit.transform.position.x + specs.mRelativePoint.x, _unit.transform.position.y + specs.mRelativePoint.y);

                    float p0_x = centerPoint.x - specs.mSize.x / 2f;
                    float p0_y = centerPoint.y + specs.mSize.y / 2f;

                    float p1_x = centerPoint.x - specs.mSize.x / 2f;
                    float p1_y = centerPoint.y - specs.mSize.y / 2f;

                    float p2_x = centerPoint.x + specs.mSize.x / 2f;
                    float p2_y = centerPoint.y - specs.mSize.y / 2f;

                    float p3_x = centerPoint.x + specs.mSize.x / 2f;
                    float p3_y = centerPoint.y + specs.mSize.y / 2f;

                    Vector2 p0 = new Vector2(p0_x, p0_y);
                    Vector2 p1 = new Vector2(p1_x, p1_y);
                    Vector2 p2 = new Vector2(p2_x, p2_y);
                    Vector2 p3 = new Vector2(p3_x, p3_y);

                    Debug.DrawLine(p0, p1, Color.red, 0.5f);
                    Debug.DrawLine(p1, p2, Color.red, 0.5f);
                    Debug.DrawLine(p2, p3, Color.red, 0.5f);
                    Debug.DrawLine(p3, p0, Color.red, 0.5f);

                    List<Collider2D> results = new List<Collider2D>();
                    Physics2D.OverlapBox(centerPoint, specs.mSize, specs.mAngle, specs.mContactFilter2D, results);

                    foreach(Collider2D col in results)
                    {
                        Unit collidingUnit = col.gameObject.GetComponent<Unit>();

                        //check against self, none, ground
                        if (collidingUnit.unitType != _unit.unitType && collidingUnit.unitType != UnitType.NONE && collidingUnit.unitType != UnitType.FLAT_GROUND)
                        {
                            _currentHitCount++;

                            if (_currentHitCount <= specs.mMaxHits)
                            {
                                Debugger.Log(_unit.name + " hit: " + col.gameObject.name);
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