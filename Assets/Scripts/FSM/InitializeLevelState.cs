using UnityEngine;

namespace FSM
{
    public class InitializeLevelState : ILevelState
    {
        private LevelStateMachine _levelStateMachine;

        public InitializeLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        void ILevelState.Enter()
        {
            Debug.Log("Enter Initialize");
            _levelStateMachine.ExitOut();
        }

        void ILevelState.Exit()
        {
            Debug.Log("Exit Initialize");
        }
    }
}
