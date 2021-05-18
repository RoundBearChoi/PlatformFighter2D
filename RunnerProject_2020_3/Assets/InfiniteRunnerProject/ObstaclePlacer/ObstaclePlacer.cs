using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ObstaclePlacer
    {
        private Unit _runner = null;
        private Transform _parentTransform = null;

        //some abstract layer where
        //even the frequency isn't an issue

        public ObstaclePlacer(Unit runner, Transform parentTransform)
        {
            _parentTransform = parentTransform;
            _runner = runner;
        }

        //this is going to be a general update()
        public void OnFixedUpdate()
        {
            //if (counter >= creationInterval)
            //{
            //    counter = 0;
            //    PlaceObstacle();
            //}
            //
            //counter++;
        }

        void PlaceObstacle()
        {
            Debugger.Log("placing obstacle..");
        }
    }
}