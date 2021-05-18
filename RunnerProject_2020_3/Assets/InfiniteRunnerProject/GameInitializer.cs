using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : MonoBehaviour
    {
        Stage _currentStage = null;

        private void Start()
        {
            ResourceLoader.Init();
            _currentStage = CreateStage(typeof(IntroStage));

            if (_currentStage != null)
            {
                _currentStage.Init();
            }
        }

        private Stage CreateStage(System.Type stageType)
        {
            if (stageType.IsSubclassOf(typeof(Stage)))
            {
                Stage newStage = Instantiate(ResourceLoader.Get(stageType)) as Stage;
                newStage.transform.parent = this.transform;
                newStage.transform.localPosition = Vector3.zero;
                newStage.transform.localRotation = Quaternion.identity;

                return newStage;
            }
            else
            {
                return null;
            }
        }

        private void Update()
        {
            if (_currentStage != null)
            {
                _currentStage.OnUpdate();

                if (_currentStage.listStageMessages.Contains(StageMessage.GOTO_INTRO_STAGE))
                {
                    Destroy(_currentStage.gameObject);
                    _currentStage = CreateStage(typeof(IntroStage));

                    if (_currentStage != null)
                    {
                        _currentStage.Init();
                    }
                }

                if (_currentStage.listStageMessages.Contains(StageMessage.GOTO_GAME_STAGE))
                {
                    Destroy(_currentStage.gameObject);
                    _currentStage = CreateStage(typeof(GameStage));

                    if (_currentStage != null)
                    {
                        _currentStage.Init();
                    }
                }
            }

            if (_currentStage != null)
            {
                _currentStage.listStageMessages.Clear();
            }
        }

        private void FixedUpdate()
        {
            if (_currentStage != null)
            {
                _currentStage.OnFixedUpdate();
            }
        }
    }
}