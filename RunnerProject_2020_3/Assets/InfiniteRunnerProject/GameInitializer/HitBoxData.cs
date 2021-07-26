using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public class HitBoxData
    {
        public OverlapBoxCollisionData runner_Attack_A;
        public OverlapBoxCollisionData runner_Attack_B;
        public OverlapBoxCollisionData golem_Attack_A;
    }
}