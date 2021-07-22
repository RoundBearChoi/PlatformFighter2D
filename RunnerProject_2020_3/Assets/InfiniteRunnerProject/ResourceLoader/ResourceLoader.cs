using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class ResourceLoader
    {
        public static StageLoader stageLoader = null;
        public static UnitLoader unitLoader = null;
        public static LevelLoader levelLoader = null;
        public static UILoader uiLoader = null;
        public static UIElementLoader uiElementLoader = null;
        public static etcLoader etcLoader = null;

        static Dictionary<string, Sprite[]> _dicSpriteSets = new Dictionary<string, Sprite[]>();

        public static void Init()
        {
            stageLoader = new StageLoader();
            unitLoader = new UnitLoader();
            levelLoader = new LevelLoader();
            uiLoader = new UILoader();
            uiElementLoader = new UIElementLoader();
            etcLoader = new etcLoader();

            _dicSpriteSets.Clear();
        }

        //fix string keys to int/hash keys
        public static Sprite[] LoadSpriteBySpec(SpriteAnimationSpec spec)
        {
            Sprite[] arrSprite = LoadSpriteByString(spec.spriteName);

            if (arrSprite.Length == 0)
            {
                arrSprite = LoadSpriteByString(spec.backupSpriteName);
            }

            return arrSprite;
        }

        public static Sprite[] LoadSpriteByString(string spriteName)
        {
            if (_dicSpriteSets.ContainsKey(spriteName))
            {
                return _dicSpriteSets[spriteName];
            }
            else
            {
                Sprite[] arrSprites = Resources.LoadAll<Sprite>(spriteName);

                if (arrSprites.Length > 0)
                {
                    _dicSpriteSets.Add(spriteName, arrSprites);
                }

                return arrSprites;
            }
        }
    }
}