using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    [CreateAssetMenu(fileName = "TargetIP", menuName = "InfiniteRunner/TargetIP/TargetIP")]
    public class TargetIP : ScriptableObject
    {
        public string hostIP;
    }
}