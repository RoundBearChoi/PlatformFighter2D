using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Client;

namespace RB
{
    public class InputDevicesStage : BaseStage
    {
        Camera _mainCam = null;

        public override void Init()
        {
            IntroCamera introCam = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.INTRO_CAMERA)) as IntroCamera;
            introCam.transform.parent = this.transform;

            _mainCam = introCam.GetComponent<Camera>();
            _mainCam.transform.position = new Vector3(0f, 0f, -5f);

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;
            
            _baseUI.Init(BaseUIType.INPUT_DEVICES_STAGE_UI);
        }

        public override void OnUpdate()
        {
            InputController.centralUserInput.commands.UpdateKeyPresses();

            if (_baseUI != null)
            {
                _baseUI.OnUpdate();
            }

            if (InputController.centralUserInput.commands.ContainsPress(CommandType.ESCAPE, true))
            {
                ReturnToMenu.Return();
            }

            if (InputController.centralUserInput.commands.ContainsPress(CommandType.ENTER, true))
            {
                for(int i = 0; i < BaseInitializer.CURRENT.arrInputDeviceUI.Length; i++)
                {
                    if (i < BaseInitializer.CURRENT.arrInputDeviceData.Length)
                    {
                        if (BaseInitializer.CURRENT.arrInputDeviceUI[i] != null)
                        {
                            BaseInitializer.CURRENT.arrInputDeviceData[i].deviceName = BaseInitializer.CURRENT.arrInputDeviceUI[i].DEVICE_NAME;
                            BaseInitializer.CURRENT.arrInputDeviceData[i].keyboard = BaseInitializer.CURRENT.arrInputDeviceUI[i].KEYBOARD;
                            BaseInitializer.CURRENT.arrInputDeviceData[i].mouse = BaseInitializer.CURRENT.arrInputDeviceUI[i].MOUSE;
                            BaseInitializer.CURRENT.arrInputDeviceData[i].gamepad = BaseInitializer.CURRENT.arrInputDeviceUI[i].GAMEPAD;

                            BaseInitializer.CURRENT.arrInputDeviceUI[i] = null;
                        }
                    }
                }

                BaseInitializer.CURRENT.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.FIGHT_STAGE));
            }
        }

        public override void OnLateUpdate()
        {
            if (_baseUI != null)
            {
                _baseUI.OnLateUpdate();
            }
        }

        public override void OnFixedUpdate()
        {
            if (_baseUI != null)
            {
                _baseUI.OnFixedUpdate();
            }
        }
    }
}