using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "StateAnimationSetter", menuName = "InfiniteRunner/StateAnimationSetter/StateAnimationSetter")]
    public class StateAnimationSetter : ScriptableObject
    {
        public void State_Runner_AttackA(SpriteAnimationSpec spec)
        {
            Runner_AttackA.SetAnimationSpec(spec);
        }

        public void State_Runner_Death(SpriteAnimationSpec spec)
        {
            Runner_Death.SetAnimationSpec(spec);
        }

        public void State_Runner_Idle(SpriteAnimationSpec spec)
        {
            Runner_Idle.SetAnimationSpec(spec);
        }

        public void State_Runner_Jump_Fall(SpriteAnimationSpec spec)
        {
            Runner_Jump_Fall.SetAnimationSpec(spec);
        }

        public void State_Runner_Jump_Up(SpriteAnimationSpec spec)
        {
            Runner_Jump_Up.SetAnimationSpec(spec);
        }

        public void State_Runner_NormalRun(SpriteAnimationSpec spec)
        {
            Runner_NormalRun.SetAnimationSpec(spec);
        }

        public void State_Golem_Idle(SpriteAnimationSpec spec)
        {
            Golem_Idle.SetAnimationSpec(spec);
        }
    }
}