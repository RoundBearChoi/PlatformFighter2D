using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OverlapBoxCollision : StateComponent
    {
        List<OverlapBoxCollisionSpecs> _listSpecs;
        int _currentHitCount = 0;

        public OverlapBoxCollision(Unit unit, List<OverlapBoxCollisionSpecs> listSpecs)
        {
            _unit = unit;
            _listSpecs = listSpecs;
        }

        public override void OnFixedUpdate()
        {
            foreach(OverlapBoxCollisionSpecs specs in _listSpecs)
            {
                if (_unit.unitData.spriteAnimations.currentAnimation.SPRITE_INDEX == specs.mTargetSpriteIndex)
                {
                    foreach(OverlapBoxBounds bounds in specs.mlistBounds)
                    {
                        Vector2 centerPoint = new Vector2(_unit.transform.position.x + bounds.mRelativePoint.x, _unit.transform.position.y + bounds.mRelativePoint.y);

                        List<Collider2D> results = BoxCalculator.GetCollisionResults(centerPoint, bounds, specs.mContactFilter2D, 0.5f);

                        foreach (Collider2D col in results)
                        {
                            Unit collidingUnit = col.gameObject.GetComponent<Unit>();

                            //check against self, none, ground
                            if (collidingUnit.unitType != _unit.unitType && collidingUnit.unitType != UnitType.NONE && collidingUnit.unitType != UnitType.FLAT_GROUND)
                            {
                                _currentHitCount++;

                                if (_currentHitCount <= specs.mMaxHits)
                                {
                                    BaseMessage winceMessage = new WinceMessage(collidingUnit);
                                    winceMessage.Register();

                                    BaseMessage attackerHitStop = new HitStopMessage(specs.mStopFrames, UnitType.RUNNER);
                                    attackerHitStop.Register();

                                    Vector2 closest = col.ClosestPoint(centerPoint);
                                    BaseMessage showBloodMessage = new BloodMessage(true, new Vector3(closest.x, closest.y, -0.5f));
                                    showBloodMessage.Register();

                                    BaseMessage shakeCam = new ShakeCameraMessage(10);
                                    shakeCam.Register();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}