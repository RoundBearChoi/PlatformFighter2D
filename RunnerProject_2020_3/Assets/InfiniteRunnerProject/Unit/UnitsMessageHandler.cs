using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnitsMessageHandler : BaseMessageHandler
    {
        private List<Unit> _listUnits = null;

        public UnitsMessageHandler(List<Unit> listUnits)
        {
            _listUnits = listUnits;
        }

        public override void HandleMessages()
        {
            foreach (BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.HITSTOP_REGISTER)
                {
                    Debugger.Log("hitstopmessage received by units: " + message.GetUnsignedIntMessage() + " frames");

                    foreach (Unit unit in _listUnits)
                    {
                        if (unit.unitType == message.GetUnitTypeMessage())
                        {
                            if (unit.unitUpdater != null)
                            {
                                unit.unitUpdater.AddHitStopFrames(message.GetUnsignedIntMessage());
                            }
                        }
                    }
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_BLOOD_5)
                {
                    GameInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.BLOOD_5);
                    Unit blood = Units.instance.GetUnit<Blood_5>();
                    blood.unitData.facingRight = message.GetBoolMessage();

                    Vector3 localPos = blood.transform.localPosition;

                    blood.transform.position = message.GetVector3Message() + localPos;

                    SetBloodLayer(blood.gameObject);
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_PARRY_EFFECT)
                {
                    GameInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.PARRY_EFFECT);
                    Unit parryEffect = Units.instance.GetUnit<ParryEffect>();
                    parryEffect.transform.position = message.GetVector3Message();
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_LANDING_DUST)
                {
                    GameInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.LANDING_DUST);
                    Unit landingDust = Units.instance.GetUnit<LandingDust>();

                    landingDust.transform.position = message.GetVector3Message();

                    //set custom scale
                    Vector2 scaleMultiplier = message.GetVector2Message();
                    SpriteAnimation spr = landingDust.unitData.spriteAnimations.GetLastSpriteAnimation();
                    float x = spr.gameObject.transform.localScale.x * scaleMultiplier.x;
                    float y = spr.gameObject.transform.localScale.y * scaleMultiplier.y;
                    spr.gameObject.transform.localScale = new Vector3(x, y, spr.gameObject.transform.localScale.z);
                    spr.SetLocalPositionOnOffset();

                    SetDustLayer(landingDust.gameObject);
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_WALLSLIDE_DUST)
                {
                    GameInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.WALLSLIDE_DUST);
                    Unit wallSlideDust = Units.instance.GetUnit<WallSlideDust>();

                    wallSlideDust.transform.position = message.GetVector3Message();
                    bool faceRight = message.GetBoolMessage();

                    wallSlideDust.unitData.facingRight = faceRight;
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_WALLJUMP_DUST)
                {
                    GameInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.WALLJUMP_DUST);
                    Unit wallJumpDust = Units.instance.GetUnit<WallJumpDust>();

                    wallJumpDust.transform.position = message.GetVector3Message();
                    bool faceRight = message.GetBoolMessage();

                    wallJumpDust.unitData.facingRight = faceRight;
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_DASH_DUST)
                {
                    GameInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.DASH_DUST);
                    Unit dashDust = Units.instance.GetUnit<DashDust>();
                    dashDust.transform.position = message.GetVector3Message();
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_STEP_DUST)
                {
                    GameInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.STEP_DUST);
                    Unit stepDust = Units.instance.GetUnit<StepDust>();
                    stepDust.transform.position = message.GetVector3Message();
                    stepDust.unitData.facingRight = message.GetBoolMessage();
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_SLIDE_DUST)
                {
                    GameInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.SLIDE_DUST);
                    Unit slideDust = Units.instance.GetUnit<SlideDust>();
                    slideDust.transform.position = message.GetVector3Message();
                    slideDust.unitData.facingRight = message.GetBoolMessage();
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_JUMP_DUST)
                {
                    GameInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.JUMP_DUST);
                    Unit slideDust = Units.instance.GetUnit<JumpDust>();
                    slideDust.transform.position = message.GetVector3Message();
                    slideDust.unitData.facingRight = message.GetBoolMessage();
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_SMASH_DUST)
                {
                    GameInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.SMASH_DUST);
                    Unit smashDust = Units.instance.GetUnit<SmashDust>();
                    smashDust.transform.position = message.GetVector3Message();
                    smashDust.unitData.facingRight = message.GetBoolMessage();
                }
            }
        }

        void SetBloodLayer(GameObject obj)
        {
            if (GameInitializer.current.GetStage() is FightStage)
            {
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, GameInitializer.current.fighterDataSO.BloodEffects_z);
            }
        }

        void SetDustLayer(GameObject obj)
        {
            if (GameInitializer.current.GetStage() is FightStage)
            {
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, GameInitializer.current.fighterDataSO.DustEffects_z);
            }
        }
    }
}