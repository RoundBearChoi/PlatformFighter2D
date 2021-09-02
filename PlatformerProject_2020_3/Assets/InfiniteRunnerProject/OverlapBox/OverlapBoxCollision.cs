using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OverlapBoxCollision : StateComponent
    {
        int _currentHitCount = 0;
        OverlapBoxCollisionData _boxCollisionData = null;

        public OverlapBoxCollision(Unit unit, OverlapBoxCollisionData boxCollisionData)
        {
            _unit = unit;
            _boxCollisionData = boxCollisionData;
        }

        public override void OnFixedUpdate()
        {
            foreach(OverlapBoxCollisionSpecs specs in _boxCollisionData.listSpecs)
            {
                if (_unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == specs.mTargetSpriteIndex)
                {
                    foreach(OverlapBoxBounds bounds in specs.mlistBounds)
                    {
                        Vector2 centerPoint = Vector2.zero;
                        
                        if (_unit.unitData.facingRight)
                        {
                            centerPoint = new Vector2(_unit.transform.position.x + bounds.mRelativePoint.x, _unit.transform.position.y + bounds.mRelativePoint.y);
                        }
                        else
                        {
                            centerPoint = new Vector2(_unit.transform.position.x - bounds.mRelativePoint.x, _unit.transform.position.y + bounds.mRelativePoint.y);
                        }
                        
                        List<Collider2D> results = BoxCalculator.GetCollisionResults(centerPoint, bounds, specs.mContactFilter2D, 0.5f);

                        foreach (Collider2D col in results)
                        {
                            Unit collidingUnit = col.gameObject.GetComponent<Unit>();

                            if (collidingUnit.unitData.hp > 0)
                            {
                                //check against self, none, ground
                                if (collidingUnit.unitType != _unit.unitType && collidingUnit.unitType != UnitType.NONE && collidingUnit.unitType != UnitType.FLAT_GROUND)
                                {
                                    _currentHitCount++;

                                    if (_currentHitCount <= specs.mMaxHits)
                                    {
                                        BaseMessage winceMessage = new Message_Wince(collidingUnit, _boxCollisionData.pushForce, _unit);
                                        winceMessage.Register();

                                        BaseMessage attackerHitStop = new Message_HitStop(specs.mStopFrames, _unit.unitType);
                                        attackerHitStop.Register();

                                        Vector2 closest = col.ClosestPoint(centerPoint);
                                        BaseMessage showBloodMessage = new Message_ShowBlood5(_unit.unitData.facingRight, new Vector3(closest.x, closest.y, GameInitializer.current.fighterDataSO.BloodEffects_z));
                                        showBloodMessage.Register();

                                        BaseMessage showParryEffectMessage = new Message_ShowParryEffect(new Vector3(closest.x, closest.y, GameInitializer.current.fighterDataSO.ParryEffects_z));
                                        showParryEffectMessage.Register();

                                        float shake = Random.Range(_boxCollisionData.camerShakeAmount_min, _boxCollisionData.camerShakeAmount_max);

                                        BaseMessage shakeCam = new Message_ShakeCameraOnTarget(_boxCollisionData.cameraShakeFrames, shake);
                                        shakeCam.Register();

                                        BaseMessage takeDamage = new Message_TakeDamage(collidingUnit, 1);
                                        takeDamage.Register();

                                        _unit.unitData.comboHitCount.AddCount();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}