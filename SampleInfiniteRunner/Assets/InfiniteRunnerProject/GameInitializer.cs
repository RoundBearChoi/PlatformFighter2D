using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : MonoBehaviour
    {
        Game game = null;

        private void Start()
        {
            ResourceLoader.Init();

            StartNewGame();
        }

        private void StartNewGame()
        {
            game = Instantiate(ResourceLoader.Get(typeof(Game))) as Game;
            game.Init();
            game.transform.parent = this.transform;
            game.transform.localPosition = Vector3.zero;
            game.transform.localRotation = Quaternion.identity;
        }

        private void Update()
        {
            if (game != null)
            {
                game.OnUpdate();

                if (game.RestartGame())
                {
                    Destroy(game.gameObject);
                    StartNewGame();
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