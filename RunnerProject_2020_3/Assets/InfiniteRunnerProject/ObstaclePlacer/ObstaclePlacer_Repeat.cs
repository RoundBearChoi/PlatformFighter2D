using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ObstaclePlacer_Repeat : State
    {
        private Unit _runner = null;
        private GameStage _gameStage = null;

        public ObstaclePlacer_Repeat(UnitData data, Unit runner, GameStage gameStage)
        {
            _unitData = data;
            _runner = runner;
            _gameStage = gameStage;
        }

        public override void Update()
        {
            Debugger.Log("creating an obstacle..");
            _gameStage.units.AddCreator(new ObstacleCreator(_gameStage.transform, _runner));
        }
    }
}