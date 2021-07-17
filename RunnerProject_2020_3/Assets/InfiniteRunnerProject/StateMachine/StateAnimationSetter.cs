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
            Runner_AttackA.animationSpec = spec;
        }

        public void State_Runner_Death(SpriteAnimationSpec spec)
        {
            Runner_Death.animationSpec = spec;
        }

        public void State_Runner_Idle(SpriteAnimationSpec spec)
        {
            Runner_Idle.animationSpec = spec;
        }

        public void State_Runner_Jump_Fall(SpriteAnimationSpec spec)
        {
            Runner_Jump_Fall.animationSpec = spec;
        }

        public void State_Runner_Jump_Up(SpriteAnimationSpec spec)
        {
            Runner_Jump_Up.animationSpec = spec;
        }

        public void State_Runner_NormalRun(SpriteAnimationSpec spec)
        {
            Runner_NormalRun.animationSpec = spec;
        }

        public void State_Runner_Wincing(SpriteAnimationSpec spec)
        {
            Runner_Wincing.animationSpec = spec;
        }

        public void State_Golem_Idle(SpriteAnimationSpec spec)
        {
            Golem_Idle.animationSpec = spec;
        }

        public void State_Golem_Attack(SpriteAnimationSpec spec)
        {
            Golem_Attack.animationSpec = spec;
        }

        public void State_Golem_Wincing(SpriteAnimationSpec spec)
        {
            Golem_Wincing.animationSpec = spec;
        }

        public void State_Golem_Death(SpriteAnimationSpec spec)
        {
            Golem_Death.animationSpec = spec;
        }

        public void State_Swamp_Grass_Idle(SpriteAnimationSpec spec)
        {
            Swamp_Grass_DefaultState.animationSpec = spec;
        }

        public void State_Swamp_River_Idle(SpriteAnimationSpec spec)
        {
            Swamp_River_DefaultState.animationSpec = spec;
        }

        public void State_Swamp_FrontTrees_Idle(SpriteAnimationSpec spec)
        {
            Swamp_FrontTrees_DefaultState.animationSpec = spec;
        }

        public void State_Swamp_BackTrees_Idle(SpriteAnimationSpec spec)
        {
            Swamp_BackTrees_DefaultState.animationSpec = spec;
        }

        public void State_LandingDust_DefaultState(SpriteAnimationSpec spec)
        {
            LandingDust_DefaultState.animationSpec = spec;
        }

        public void State_StepDust_DefaultState(SpriteAnimationSpec spec)
        {
            StepDust_DefaultState.animationSpec = spec;
        }

        public void State_Blood_5_DefaultState(SpriteAnimationSpec spec)
        {
            Blood_5_DefaultState.animationSpec = spec;
        }

        public void State_ParryEffect_DefaultState(SpriteAnimationSpec spec)
        {
            ParryEffect_DefaultState.animationSpec = spec;
        }
    }
}