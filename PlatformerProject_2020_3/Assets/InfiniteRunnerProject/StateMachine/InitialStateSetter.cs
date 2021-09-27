using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "InitialStateSetter", menuName = "InfiniteRunner/Setters/InitialStateSetter")]
    public class InitialStateSetter : ScriptableObject
    {
        public void New_Runner_Idle(Unit unit)
        {
            unit.iStateController.SetNewState(new Runner_Idle(unit));
        }

        public void New_Golem_Idle(Unit unit)
        {
            unit.iStateController.SetNewState(new Golem_Idle(unit));
        }

        public void New_Swamp_Grass(Unit unit)
        {
            unit.iStateController.SetNewState(new Swamp_Grass_DefaultState(unit));
        }

        public void New_Swamp_River(Unit unit)
        {
            unit.iStateController.SetNewState(new Swamp_River_DefaultState(unit));
        }

        public void New_Swamp_FrontTrees(Unit unit)
        {
            unit.iStateController.SetNewState(new Swamp_FrontTrees_DefaultState(unit));
        }

        public void New_Swamp_BackTrees(Unit unit)
        {
            unit.iStateController.SetNewState(new Swamp_BackTrees_DefaultState(unit));
        }

        public void New_OldCity_Platforms(Unit unit)
        {
            unit.iStateController.SetNewState(new OldCity_Platforms_DefaultState(unit));
        }

        public void New_OldCity_Arches(Unit unit)
        {
            unit.iStateController.SetNewState(new OldCity_Arches_DefaultState(unit));
        }

        public void New_OldCity_Pillars(Unit unit)
        {
            unit.iStateController.SetNewState(new OldCity_Pillars_DefaultState(unit));
        }

        public void New_OldCity_BottomFog(Unit unit)
        {
            unit.iStateController.SetNewState(new OldCity_BottomFog_DefaultState(unit));
        }

        public void New_OldCity_TopFog(Unit unit)
        {
            //unit.iStateController.SetNewState(new OldCity_Pillars_DefaultState(unit));
        }

        public void New_LandingDust(Unit unit)
        {
            unit.iStateController.SetNewState(new LandingDust_DefaultState(unit));
        }

        public void New_StepDust(Unit unit)
        {
            unit.iStateController.SetNewState(new StepDust_DefaultState(unit));
        }

        public void New_DashDust(Unit unit)
        {
            unit.iStateController.SetNewState(new DashDust_DefaultState(unit));
        }

        public void New_SlideDust(Unit unit)
        {
            unit.iStateController.SetNewState(new SlideDust_DefaultState(unit));
        }

        public void New_JumpDust(Unit unit)
        {
            unit.iStateController.SetNewState(new JumpDust_DefaultState(unit));
        }

        public void New_SmashDust(Unit unit)
        {
            unit.iStateController.SetNewState(new SmashDust_DefaultState(unit));
        }

        public void New_WallSlideDust(Unit unit)
        {
            unit.iStateController.SetNewState(new WallSlideDust_DefaultState(unit));
        }

        public void New_WallJumpDust(Unit unit)
        {
            unit.iStateController.SetNewState(new WallJumpDust_DefaultState(unit));
        }

        public void New_Blood_5(Unit unit)
        {
            unit.iStateController.SetNewState(new Blood_5_DefaultState(unit));
        }

        public void New_DeathFX_DARK(Unit unit)
        {
            unit.iStateController.SetNewState(new DeathFX_Dark_DefaultState(unit));
        }

        public void New_ParryEffect(Unit unit)
        {
            unit.iStateController.SetNewState(new ParryEffect_DefaultState(unit));
        }

        public void New_LittleRed_Idle(Unit unit)
        {
            unit.iStateController.SetNewState(new LittleRed_Idle(unit));
        }
    }
}