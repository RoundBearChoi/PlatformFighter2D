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
            Runner_Attack_A.animationSpec = spec;
        }

        public void State_Runner_AttackA_Slash(SpriteAnimationSpec spec)
        {
            Runner_Attack_A_Dash.animationSpec = spec;
        }

        public void State_Runner_AttackB(SpriteAnimationSpec spec)
        {
            Runner_Attack_B.animationSpec = spec;
        }

        public void State_Runner_Smash_Grounded(SpriteAnimationSpec spec)
        {
            Runner_Smash_Grounded.animationSpec = spec;
        }

        public void State_Runner_Smash_Prep(SpriteAnimationSpec spec)
        {
            Runner_Smash_Prep.animationSpec = spec;
        }

        public void State_Runner_Smash_Air_Land(SpriteAnimationSpec spec)
        {
            Runner_Smash_Air_Land.animationSpec = spec;
        }

        public void State_Runner_Overhead(SpriteAnimationSpec spec)
        {
            Runner_Overhead.animationSpec = spec;
        }

        public void State_Runner_Death(SpriteAnimationSpec spec)
        {
            Runner_Death.animationSpec = spec;
        }

        public void State_Runner_tempDeath(SpriteAnimationSpec spec)
        {
            tempRunner_Death.animationSpec = spec;
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

        public void State_Runner_Slide(SpriteAnimationSpec spec)
        {
            Runner_Slide.animationSpec = spec;
        }

        public void State_Runner_Slide_GetUp(SpriteAnimationSpec spec)
        {
            Runner_Slide_GetUp.animationSpec = spec;
        }

        public void State_Runner_Crouch(SpriteAnimationSpec spec)
        {
            Runner_Crouch.animationSpec = spec;
        }

        public void State_Runner_Crouch_GetUp(SpriteAnimationSpec spec)
        {
            Runner_Crouch_GetUp.animationSpec = spec;
        }

        public void State_Golem_Idle(SpriteAnimationSpec spec)
        {
            Golem_Idle.animationSpec = spec;
        }

        public void State_Golem_Attack(SpriteAnimationSpec spec)
        {
            Golem_Attack_A.animationSpec = spec;
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

        public void State_DashDust_DefaultState(SpriteAnimationSpec spec)
        {
            DashDust_DefaultState.animationSpec = spec;
        }

        public void State_SlideDust_DefaultState(SpriteAnimationSpec spec)
        {
            SlideDust_DefaultState.animationSpec = spec;
        }
        public void State_JumpDust_DefaultState(SpriteAnimationSpec spec)
        {
            JumpDust_DefaultState.animationSpec = spec;
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