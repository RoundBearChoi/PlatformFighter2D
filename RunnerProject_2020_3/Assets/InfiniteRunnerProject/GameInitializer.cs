using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : MonoBehaviour
    {
        GameStage game = null;
        IntroStage intro = null;

        private void Start()
        {
            ResourceLoader.Init();

            StartIntroStage();
        }

        private void StartGameStage()
        {
            game = Instantiate(ResourceLoader.Get(typeof(GameStage))) as GameStage;
            game.Init();
            game.transform.parent = this.transform;
            game.transform.localPosition = Vector3.zero;
            game.transform.localRotation = Quaternion.identity;
        }

        private void StartIntroStage()
        {
            intro = Instantiate(ResourceLoader.Get(typeof(IntroStage))) as IntroStage;
            intro.Init();
            intro.transform.parent = this.transform;
            intro.transform.localPosition = Vector3.zero;
            intro.transform.localRotation = Quaternion.identity;
        }

        private void Update()
        {
            if (game != null)
            {
                game.OnUpdate();

                if (game.listStageMessages.Contains(StageMessage.RESTART_GAME))
                {
                    Destroy(game.gameObject);
                    game = null;
                    StartGameStage();
                }

                if (game.listStageMessages.Contains(StageMessage.GOTO_INTRO_STAGE))
                {
                    Destroy(game.gameObject);
                    game = null;
                    StartIntroStage();
                }
            }

            if (intro != null)
            {
                intro.OnUpdate();

                if (intro.listStageMessages.Contains(StageMessage.GOTO_GAME_STAGE))
                {
                    Destroy(intro.gameObject);
                    intro = null;
                    StartGameStage();
                }
            }

            if (intro != null)
            {
                intro.listStageMessages.Clear();
            }

            if (game != null)
            {
                game.listStageMessages.Clear();
            }
        }

        private void FixedUpdate()
        {
            if (game != null)
            {
                game.OnFixedUpdate();
            }
        }
    }
}