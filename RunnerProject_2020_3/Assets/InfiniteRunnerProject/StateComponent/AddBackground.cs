using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class AddBackground<T> : StateComponent where T : UnitState
    {
        UnitState _state = null;

        public AddBackground(UnitState state)
        {
            _state = state;
        }

        public override void OnFixedUpdate()
        {
            if (_state.fixedUpdateCount >= 1)
            {
                UnitState latest = _state.GetLastestInstantiatedState();

                if (latest != null)
                {
                    if (latest == _state)
                    {
                        if (latest.ownerUnit.unitData.spriteAnimations.GetCurrentAnimation() != null)
                        {
                            Vector2[] latest_edges = latest.ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().GetSpriteWorldEdges(0);

                            foreach (Vector2 edge in latest_edges)
                            {
                                Debug.DrawLine(Vector3.zero, edge, Color.blue, 0.1f);
                            }

                            if (latest_edges[3].x <= CameraScript.current.cameraEdges.GetEdges()[3].x)
                            {
                                Debugger.Log("adding additional background: " + _state.GetType().Name);
                                GameInitializer.current.STAGE.backgroundSetup.AddAdditionalAdjacentUnit<T>();
                            }
                        }
                    }
                }
            }
        }
    }
}