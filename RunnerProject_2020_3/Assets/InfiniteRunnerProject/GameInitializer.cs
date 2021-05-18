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
            _currentStage = CreateStage(typeof(GameStage));
            _currentStage.Init();
        }

        private Stage CreateStage(System.Type stageType)
        {
            Stage newStage = Instantiate(ResourceLoader.Get(stageType)) as Stage;
            newStage.transform.parent = this.transform;
            newStage.transform.localPosition = Vector3.zero;
            newStage.transform.localRotation = Quaternion.identity;

            return newStage;
        }

        private void Update()
        {
            if (_currentStage != null)
            {
                _currentStage.OnUpdate();

                if (_currentStage.listStageMessages.Contains(StageMessage.RESTART_GAME))
                {
                    Destroy(_currentStage.gameObject);
                    _currentStage = null;

                    _currentStage = CreateStage(typeof(GameStage));
                    _currentStage.Init();
                }

                //if (game.listStageMessages.Contains(StageMessage.GOTO_INTRO_STAGE))
                //{
                //    Destroy(game.gameObject);
                //    game = null;
                //    StartIntroStage();
                //}
            }

            if (_currentStage != null)
            {
                _currentStage.listStageMessages.Clear();
            }

            //if (intro != null)
            //{
            //    intro.OnUpdate();
            //
            //    if (intro.listStageMessages.Contains(StageMessage.GOTO_GAME_STAGE))
            //    {
            //        Destroy(intro.gameObject);
            //        intro = null;
            //        StartGameStage();
            //    }
            //}
            //
            //if (intro != null)
            //{
            //    intro.listStageMessages.Clear();
            //}
            //
            //if (game != null)
            //{
            //    game.listStageMessages.Clear();
            //}
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