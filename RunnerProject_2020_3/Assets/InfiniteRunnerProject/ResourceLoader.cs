using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class ResourceLoader
    {
        static Dictionary<System.Type, Object> dicResources = new Dictionary<System.Type, Object>();
        static Dictionary<int, Object> dicLevels = new Dictionary<int, Object>();
        static Dictionary<SpriteType, Object> dicSprites = new Dictionary<SpriteType, Object>();

        public static void Init()
        {
            GameStage game = Resources.Load("GameStage", typeof(GameStage)) as GameStage;
            dicResources.Add(game.GetType(), game);

            IntroStage intro = Resources.Load("IntroStage", typeof(IntroStage)) as IntroStage;
            dicResources.Add(intro.GetType(), intro);

            Runner runner = Resources.Load("Prefab_Runner", typeof(Runner)) as Runner;
            dicResources.Add(runner.GetType(), runner);

            Obstacle obstacle = Resources.Load("Obstacle", typeof(Obstacle)) as Obstacle;
            dicResources.Add(obstacle.GetType(), obstacle);

            UI ui = Resources.Load("UI", typeof(UI)) as UI;
            dicResources.Add(ui.GetType(), ui);

            DefaultUIBlock defaultUIBlock = Resources.Load("DefaultUIBlock", typeof(DefaultUIBlock)) as DefaultUIBlock;
            dicResources.Add(defaultUIBlock.GetType(), defaultUIBlock);

            RunnerDeathNotification deathNotification = Resources.Load("RunnerDeathNotification", typeof(RunnerDeathNotification)) as RunnerDeathNotification;
            dicResources.Add(deathNotification.GetType(), deathNotification);

            //levels
            dicLevels.Add(1, Resources.Load("Level_1_Temp"));
        }

        public static Object GetResource(System.Type _type)
        {
            if (dicResources.ContainsKey(_type))
            {
                return dicResources[_type];
            }
            else
            {
                return null;
            }
        }

        public static Object GetLevel(int levelIndex)
        {
            if (dicLevels.ContainsKey(levelIndex))
            {
                return dicLevels[levelIndex];
            }
            else
            {
                return null;
            }
        }
    }
}