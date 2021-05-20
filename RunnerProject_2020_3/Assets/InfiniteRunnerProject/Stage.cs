using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Stage : MonoBehaviour
    {
        protected GameInitializer _gameIntializer = null;

        public virtual void Init()
        {

        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void SetInitializer(GameInitializer gameInitializer)
        {
            _gameIntializer = gameInitializer;
        }
    }
}