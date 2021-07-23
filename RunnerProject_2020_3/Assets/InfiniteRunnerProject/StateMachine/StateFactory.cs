using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "StateFactory", menuName = "InfiniteRunner/StateFactory/StateFactory")]
    public class StateFactory : ScriptableObject
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

        public void New_Blood_5(Unit unit)
        {
            unit.iStateController.SetNewState(new Blood_5_DefaultState(unit));
        }

        public void New_ParryEffect(Unit unit)
        {
            unit.iStateController.SetNewState(new ParryEffect_DefaultState(unit));
        }
    }
}