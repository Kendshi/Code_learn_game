using MG_BlocksEngine2.Environment;
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
            var curLevel = Object.FindObjectOfType<LevelSettings>();
            var player = Object.Instantiate(Resources.Load<GameObject>("Player"), curLevel.StartPoint.position, Quaternion.identity);
            Object.FindObjectOfType<PlayerCamera>().SetTarget(player.transform);
            Object.FindObjectOfType<BE2_ProgrammingEnv>().targetObject = player.GetComponent<BE2_TargetObject>();
            _levelStateMachine.ExitOut();
        }

        void ILevelState.Exit()
        {
            Debug.Log("Exit Initialize");
        }
    }
}
