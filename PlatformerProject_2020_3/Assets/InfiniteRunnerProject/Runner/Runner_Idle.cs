using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Idle : UnitState
    {
        public Runner_Idle()
        {
            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_IDLE);
        }

        public override void OnUpdate()
        {
            if (UnityEngine.InputSystem.Keyboard.current.anyKey.wasReleasedThisFrame)
            {
                BaseInitializer.CURRENT.RunCoroutine(TriggerRun());
            }
        }

        IEnumerator TriggerRun()
        {
            yield return new WaitForEndOfFrame();
            _ownerUnit.listNextStates.Add(new Runner_NormalRun());
        }
    }
}