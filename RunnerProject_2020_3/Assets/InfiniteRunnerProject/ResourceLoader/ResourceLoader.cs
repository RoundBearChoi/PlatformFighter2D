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

        public static void Init()
        {
            stageLoader = new StageLoader();
            unitLoader = new UnitLoader();
            levelLoader = new LevelLoader();
            uiLoader = new UILoader();
            uiElementLoader = new UIElementLoader();
            etcLoader = new etcLoader();
        }
    }
}