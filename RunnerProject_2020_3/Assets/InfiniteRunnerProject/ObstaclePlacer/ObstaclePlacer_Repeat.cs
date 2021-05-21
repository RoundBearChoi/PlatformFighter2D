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
            Debugger.Log("updating obstacle placer..");

            ObstacleCreator obstacleCreator = new ObstacleCreator(_gameStage.transform, _runner);
            Unit obstacle = obstacleCreator.GetUnit();

            obstacle.transform.position += new Vector3(_runner.transform.position.x + 10f, 0f, 0f);

            _gameStage.units.AddUnit(obstacle);
        }
    }
}