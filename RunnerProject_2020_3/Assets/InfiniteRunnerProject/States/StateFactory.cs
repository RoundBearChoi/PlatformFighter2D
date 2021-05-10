using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class StateFactory
    {
        public static State Create_CameraController_SimpleFollow(Unit runner, Camera maincam)
        {
            return new CameraController_SimpleFollow(runner, maincam);
        }

        public static State Create_Obstacle_Idle(UnitData unitData)
        {
            return new Obstacle_Idle(unitData);
        }

        public static State Create_Runner_Idle(UnitData unitData, UserInput userInput)
        {
            return new Runner_Idle(unitData, userInput);
        }

        public static State Create_Runner_Jump_Fall(UnitData unitData, UserInput userInput)
        {
            return new Runner_Jump_Fall(unitData, userInput);
        }

        public static State Create_Runner_Jump_Up(UnitData unitData, UserInput userInput)
        {
            return new Runner_Jump_Up(unitData, userInput);
        }

        public static State Create_Runner_NormalRun(UnitData unitData, UserInput userInput)
        {
            return new Runner_NormalRun(unitData, userInput);
        }

        public static State Create_Runner_Death_Up(UnitData unitData)
        {
            return new Runner_Death_Up(unitData);
        }

        public static State Create_Runner_Death_Down(UnitData unitData)
        {
            return new Runner_Death_Down(unitData);
        }
    }
}