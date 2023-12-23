using UnityEngine;

namespace FSM
{
    public class LoadingLevelState : ILevelState
    {
        private LevelStateMachine _levelStateMachine;

        public LoadingLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        void ILevelState.Enter()
        {
            Debug.Log("Enter Loading");
            _levelStateMachine.EnterIn<InitializeLevelState>();
        }

        void ILevelState.Exit()
        {
            Debug.Log("Exit Loading");
            
        }
    }
}
