using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    public struct PlayerDataset<T>
    {
        public int playerCount;
        public List<int> listIDs;
        public List<T> listData;
    }
}