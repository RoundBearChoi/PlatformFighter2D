using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "OverlapBoxCollisionData", menuName = "InfiniteRunner/OverlapBoxCollisionData/OverlapBoxCollisionData")]
    public class OverlapBoxCollisionData : ScriptableObject
    {
        public OverlapBoxDataType overlapBoxDataType = OverlapBoxDataType.NONE;
        public List<OverlapBoxCollisionSpecs> listSpecs = new List<OverlapBoxCollisionSpecs>();
        public Vector2 pushForce = new Vector2();
        public uint cameraShakeFrames = 0;
    }
}