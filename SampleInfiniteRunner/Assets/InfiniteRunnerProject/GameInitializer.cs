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

            game = Instantiate(ResourceLoader.Get(typeof(Game))) as Game;
            game.transform.parent = this.transform;
            game.transform.localPosition = Vector3.zero;
            game.transform.localRotation = Quaternion.identity;
        }
    }
}