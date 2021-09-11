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

        public bool IDAndDataCountMatch()
        {
            if (listIDs != null)
            {
                if (listData != null)
                {
                    if (listIDs.Count == listData.Count)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}