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
            GameStage gameStage = Resources.Load("GameStage", typeof(GameStage)) as GameStage;
            dicResources.Add(gameStage.GetType(), gameStage);

            RunnerStage runnerStage = Resources.Load("RunnerStage", typeof(RunnerStage)) as RunnerStage;
            dicResources.Add(runnerStage.GetType(), runnerStage);

            IntroStage introStage = Resources.Load("IntroStage", typeof(IntroStage)) as IntroStage;
            dicResources.Add(introStage.GetType(), introStage);

            SpritesStage spritesStage = Resources.Load("SpritesStage", typeof(SpritesStage)) as SpritesStage;
            dicResources.Add(spritesStage.GetType(), spritesStage);

            Runner runner = Resources.Load("Prefab_Runner", typeof(Runner)) as Runner;
            dicResources.Add(runner.GetType(), runner);

            SampleLeftEnemy frontEnemy = Resources.Load("SampleFrontEnemy", typeof(SampleLeftEnemy)) as SampleLeftEnemy;
            dicResources.Add(frontEnemy.GetType(), frontEnemy);

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