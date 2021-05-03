using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class ResourceLoader
    {
        static Dictionary<System.Type, Object> dicResources = new Dictionary<System.Type, Object>();
        static Dictionary<SpriteType, Object> dicSprites = new Dictionary<SpriteType, Object>();

        public static void Init()
        {
            Runner runner = Resources.Load("Runner", typeof(Runner)) as Runner;
            CollisionDetector collisionDetector = Resources.Load("CollisionDetector", typeof(CollisionDetector)) as CollisionDetector;

            dicResources.Add(runner.GetType(), runner);
            dicResources.Add(collisionDetector.GetType(), collisionDetector);

            dicSprites.Add(SpriteType.RUNNER_SAMPLE, Resources.Load("RunnerSampleSprite") as GameObject);
        }

        public static Object Get(System.Type _type)
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

        public static Object GetSprite(SpriteType _spriteType)
        {
            if (dicSprites.ContainsKey(_spriteType))
            {
                return dicSprites[_spriteType];
            }
            else
            {
                return null;
            }
        }
    }
}