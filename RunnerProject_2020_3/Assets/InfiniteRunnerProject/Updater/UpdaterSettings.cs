using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public class UpdaterSettings
    {
        public bool useCustomUpdater;

        public BaseUpdater GetUpdater(UpdaterType updaterType)
        {
            if (updaterType == UpdaterType.DEFAULT_UPDATER)
            {
                return new DefaultUpdater();
            }

            return null;
        }
    }
}