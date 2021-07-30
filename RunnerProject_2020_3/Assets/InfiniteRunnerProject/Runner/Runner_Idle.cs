using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Idle : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Idle(Unit unit)
        {
            ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_IDLE);
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnUpdate()
        {
            if (UserInput.keyboard.anyKey.wasReleasedThisFrame)
            {
                GameInitializer.current.RunCoroutine(TriggerRun());
            }
        }

        IEnumerator TriggerRun()
        {
            yield return new WaitForEndOfFrame();
            ownerUnit.unitData.listNextStates.Add(new Runner_NormalRun(ownerUnit));
        }
    }
}