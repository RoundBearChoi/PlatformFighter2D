using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct DamageData
    {
        public DamageData(float damage, Unit attacker)
        {
            damageAmount = damage;
            attackingUnit = attacker;
        }

        public float damageAmount;
        public Unit attackingUnit;
    }
}