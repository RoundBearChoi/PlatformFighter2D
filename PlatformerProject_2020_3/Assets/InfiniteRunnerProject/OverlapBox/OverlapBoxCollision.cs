using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OverlapBoxCollision : StateComponent
    {
        int _currentHitCount = 0;
        OverlapBoxCollisionData _boxCollisionData = null;

        public OverlapBoxCollision(UnitState unitState, OverlapBoxCollisionData boxCollisionData)
        {
            _unitState = unitState;
            _boxCollisionData = boxCollisionData;
        }

        public override void OnFixedUpdate()
        {
            foreach(OverlapBoxCollisionSpecs specs in _boxCollisionData.listSpecs)
            {
                if (UNIT_DATA.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == specs.mTargetSpriteIndex)
                {
                    foreach(OverlapBoxBounds bounds in specs.mlistBounds)
                    {
                        Vector2 centerPoint = Vector2.zero;
                        
                        if (UNIT_DATA.facingRight)
                        {
                            centerPoint = new Vector2(UNIT.transform.position.x + bounds.mRelativePoint.x, UNIT.transform.position.y + bounds.mRelativePoint.y);
                        }
                        else
                        {
                            centerPoint = new Vector2(UNIT.transform.position.x - bounds.mRelativePoint.x, UNIT.transform.position.y + bounds.mRelativePoint.y);
                        }
                        
                        List<Collider2D> results = BoxCalculator.GetCollisionResults(centerPoint, bounds, specs.mContactFilter2D, 0.5f);

                        foreach (Collider2D col in results)
                        {
                            Unit collidingUnit = col.gameObject.GetComponent<Unit>();

                            if (collidingUnit != null)
                            {
                                if (collidingUnit.unitData.hp > 0)
                                {
                                    //check against self, none, ground
                                    if (collidingUnit.unitType != UNIT.unitType && collidingUnit.unitType != UnitType.NONE)
                                    {
                                        _currentHitCount++;

                                        if (_currentHitCount <= specs.mMaxHits)
                                        {
                                            BaseMessage winceMessage = new Message_Wince(collidingUnit, _boxCollisionData.pushForce, UNIT);
                                            winceMessage.Register();

                                            BaseMessage attackerHitStop = new Message_HitStop(specs.mStopFrames, UNIT.unitType);
                                            attackerHitStop.Register();

                                            Vector2 closest = col.ClosestPoint(centerPoint);
                                            BaseMessage showBloodMessage = new Message_ShowBlood5(UNIT_DATA.facingRight, new Vector3(closest.x, closest.y, BaseInitializer.CURRENT.fighterDataSO.BloodEffects_z));
                                            showBloodMessage.Register();

                                            BaseMessage showParryEffectMessage = new Message_ShowParryEffect(new Vector3(closest.x, closest.y, BaseInitializer.CURRENT.fighterDataSO.ParryEffects_z));
                                            showParryEffectMessage.Register();

                                            float shake = Random.Range(_boxCollisionData.camerShakeAmount_min, _boxCollisionData.camerShakeAmount_max);

                                            BaseMessage shakeCam = new Message_ShakeCameraOnTarget(BaseInitializer.CURRENT.STAGE.CAMERA_SCRIPT, _boxCollisionData.cameraShakeFrames, shake);
                                            shakeCam.Register();

                                            BaseMessage takeDamage = new Message_TakeDamage(collidingUnit, 10);
                                            takeDamage.Register();
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
}