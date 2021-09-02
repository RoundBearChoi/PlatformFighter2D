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
                    BaseInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.BLOOD_5);
                    Unit blood = Units.instance.GetUnit<Blood_5>();
                    blood.unitData.facingRight = message.GetBoolMessage();

                    Vector3 localPos = blood.transform.localPosition;

                    blood.transform.position = message.GetVector3Message() + localPos;

                    SetBloodLayer(blood.gameObject);
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_PARRY_EFFECT)
                {
                    BaseInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.PARRY_EFFECT);
                    Unit parryEffect = Units.instance.GetUnit<ParryEffect>();
                    parryEffect.transform.position = message.GetVector3Message();
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_LANDING_DUST)
                {
                    IHandleMessage handle = new Handle_LandingDust(message.GetVector3Message(), message.GetVector2Message(), message.GetBoolMessage());
                    
                    if (handle.Handle())
                    {
                        Unit landingDust = Units.instance.GetUnit<LandingDust>();
                        SetDustLayer(landingDust.gameObject);
                    }
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_WALLSLIDE_DUST)
                {
                    IHandleMessage handle = new Handle_WallSlideDust(message.GetVector3Message(), message.GetBoolMessage());
                    handle.Handle();
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_WALLJUMP_DUST)
                {
                    BaseInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.WALLJUMP_DUST);
                    Unit wallJumpDust = Units.instance.GetUnit<WallJumpDust>();

                    wallJumpDust.transform.position = message.GetVector3Message();
                    bool faceRight = message.GetBoolMessage();

                    wallJumpDust.unitData.facingRight = faceRight;
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_DASH_DUST)
                {
                    BaseInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.DASH_DUST);
                    Unit dashDust = Units.instance.GetUnit<DashDust>();
                    dashDust.transform.position = message.GetVector3Message();
                    dashDust.unitData.facingRight = message.GetBoolMessage();
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_STEP_DUST)
                {
                    BaseInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.STEP_DUST);
                    Unit stepDust = Units.instance.GetUnit<StepDust>();
                    stepDust.transform.position = message.GetVector3Message();
                    stepDust.unitData.facingRight = message.GetBoolMessage();

                    SpriteAnimation spr = stepDust.unitData.spriteAnimations.GetLastSpriteAnimation();

                    uint interval = message.GetUnsignedIntMessage();
                    spr.SetSpriteInterval(interval);

                    Vector2 scaleMultiplier = message.GetVector2Message();
                    spr.gameObject.transform.localScale = new Vector3(spr.gameObject.transform.localScale.x * scaleMultiplier.x, spr.gameObject.transform.localScale.y * scaleMultiplier.y, 1f);
                    spr.SetLocalPositionOnOffset();
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_SLIDE_DUST)
                {
                    BaseInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.SLIDE_DUST);
                    Unit slideDust = Units.instance.GetUnit<SlideDust>();
                    slideDust.transform.position = message.GetVector3Message();
                    slideDust.unitData.facingRight = message.GetBoolMessage();
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_JUMP_DUST)
                {
                    BaseInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.JUMP_DUST);
                    Unit slideDust = Units.instance.GetUnit<JumpDust>();
                    slideDust.transform.position = message.GetVector3Message();
                    slideDust.unitData.facingRight = message.GetBoolMessage();
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_SMASH_DUST)
                {
                    BaseInitializer.current.GetStage().InstantiateUnit_ByUnitType(UnitType.SMASH_DUST);
                    Unit smashDust = Units.instance.GetUnit<SmashDust>();
                    smashDust.transform.position = message.GetVector3Message();
                    smashDust.unitData.facingRight = message.GetBoolMessage();
                }
            }
        }

        void SetBloodLayer(GameObject obj)
        {
            if (BaseInitializer.current.GetStage() is FightStage)
            {
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, BaseInitializer.current.fighterDataSO.BloodEffects_z);
            }
        }

        void SetDustLayer(GameObject obj)
        {
            if (BaseInitializer.current.GetStage() is FightStage)
            {
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, BaseInitializer.current.fighterDataSO.DustEffects_z);
            }
        }
    }
}