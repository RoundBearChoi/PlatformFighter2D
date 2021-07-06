using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class ResourceLoader
    {
        static Dictionary<System.Type, Object> dicResources = new Dictionary<System.Type, Object>();

        public static StageLoader stageLoader = new StageLoader();
        public static UnitLoader unitLoader = new UnitLoader();
        public static LevelLoader levelLoader = new LevelLoader();

        public static void Init()
        {
            //Ground flatGround = Resources.Load("FlatGround", typeof(Ground)) as Ground;
            //dicResources.Add(flatGround.GetType(), flatGround);

            //etc
            UI ui = Resources.Load("UI", typeof(UI)) as UI;
            dicResources.Add(ui.GetType(), ui);

            DefaultUIBlock defaultUIBlock = Resources.Load("DefaultUIBlock", typeof(DefaultUIBlock)) as DefaultUIBlock;
            dicResources.Add(defaultUIBlock.GetType(), defaultUIBlock);

            RunnerDeathNotification deathNotification = Resources.Load("RunnerDeathNotification", typeof(RunnerDeathNotification)) as RunnerDeathNotification;
            dicResources.Add(deathNotification.GetType(), deathNotification);
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
    }
}