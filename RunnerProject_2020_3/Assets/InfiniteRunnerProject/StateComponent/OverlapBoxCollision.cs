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
                                    Debugger.Log(_unit.name + " hit: " + col.gameObject.name + " (spriteindex: " + _unit.unitData.spriteAnimations.currentAnimation.SPRITE_INDEX + ")");

                                    BaseMessage winceMessage = new WinceMessage(collidingUnit, MessageType.WINCE);
                                    winceMessage.Register();

                                    BaseMessage hitStopMessage = new HitStopMessage(specs.mStopFrames, _unit, MessageType.HITSTOP_REGISTER_ALL);
                                    hitStopMessage.Register();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}