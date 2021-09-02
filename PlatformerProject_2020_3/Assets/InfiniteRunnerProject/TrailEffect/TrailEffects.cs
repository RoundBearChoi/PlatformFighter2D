using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TrailEffects
    {
        private List<TrailEffect> _listTrails = new List<TrailEffect>();

        public void AddTrail(TrailEffect trail)
        {
            _listTrails.Add(trail);
        }

        public void RemoveTrail(TrailEffect trail)
        {
            _listTrails.Remove(trail);
        }

        public void OnUpdate()
        {
            for (int i = _listTrails.Count - 1; i >= 0; i--)
            {
                _listTrails[i].OnUpdate();

                if (_listTrails[i].ALPHA <= 0.01f)
                {
                    GameObject.Destroy(_listTrails[i].gameObject);
                    _listTrails.RemoveAt(i);
                }
            }
        }
    }
}