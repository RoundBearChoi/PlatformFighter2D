using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "UpdaterFactory", menuName = "InfiniteRunner/UpdaterFactory/UpdaterFactory")]
    public class UpdaterFactory : ScriptableObject
    {
        public void New_Updater_Default(Unit unit)
        {
            unit.unitUpdater = new DefaultUpdater();
            unit.unitUpdater.SetOwnerUnit(unit);
        }
    }
}