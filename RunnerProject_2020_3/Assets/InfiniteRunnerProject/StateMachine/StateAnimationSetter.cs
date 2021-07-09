using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "StateAnimationSetter", menuName = "InfiniteRunner/StateAnimationSetter/StateAnimationSetter")]
    public class StateAnimationSetter : ScriptableObject
    {
        public void State_Runner_AttackA()
        {
            Runner_AttackA.SetAnimationSpec();
        }

        public void State_Runner_Death()
        {
            Runner_Death.SetAnimationSpec();
        }

        public void State_Runner_Idle()
        {
            Runner_Idle.SetAnimationSpec();
        }

        public void State_Runner_Jump_Fall()
        {
            Runner_Jump_Fall.SetAnimationSpec();
        }

        public void State_Runner_Jump_Up()
        {
            Runner_Jump_Up.SetAnimationSpec();
        }

        public void State_Runner_NormalRun()
        {
            Runner_NormalRun.SetAnimationSpec();
        }
    }
}