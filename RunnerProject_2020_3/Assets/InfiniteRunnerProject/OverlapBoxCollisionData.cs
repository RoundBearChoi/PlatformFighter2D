using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "OverlapBoxCollisionData", menuName = "InfiniteRunner/OverlapBoxCollisionData/OverlapBoxCollisionData")]
    public class OverlapBoxCollisionData : ScriptableObject
    {
        public List<OverlapBoxCollisionSpecs> listSpecs = new List<OverlapBoxCollisionSpecs>();
    }
}