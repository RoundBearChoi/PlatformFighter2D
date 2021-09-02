using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "UpdaterSetter", menuName = "InfiniteRunner/Setters/UpdaterSetter")]
    public class UpdaterSetter : ScriptableObject
    {
        public void New_Updater_Default(Unit unit)
        {
            unit.unitUpdater = new DefaultUnitUpdater(unit);
        }
    }
}