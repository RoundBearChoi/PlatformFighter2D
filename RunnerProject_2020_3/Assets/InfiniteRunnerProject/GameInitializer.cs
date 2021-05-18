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
            intro.transform.parent = this.transform;
            intro.transform.localPosition = Vector3.zero;
            intro.transform.localRotation = Quaternion.identity;
        }

        private void Update()
        {
            if (game != null)
            {
                game.OnUpdate();

                if (game.RestartGame())
                {
                    Destroy(game.gameObject);
                    game = null;
                    StartGameStage();
                }

                if (game.ReturnToIntro())
                {
                    Destroy(game.gameObject);
                    game = null;
                    StartIntroStage();
                }
            }

            if (intro != null)
            {
                if (intro.EnterPressed)
                {
                    Destroy(intro.gameObject);
                    intro = null;
                    StartGameStage();
                }
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