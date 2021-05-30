using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FrontEnemyCreator : UnitCreator
    {
        public override Unit GetUnit()
        {
            SampleLeftEnemy enemy = GameObject.Instantiate(ResourceLoader.GetResource(typeof(SampleLeftEnemy))) as SampleLeftEnemy;
            enemy.unitData = new UnitData(enemy.transform);

            return enemy;
        }
    }
}