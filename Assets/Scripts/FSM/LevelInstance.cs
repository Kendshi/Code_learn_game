using UnityEngine;

namespace FSM
{
    public class LevelInstance : MonoBehaviour
    {
        private LevelStateMachine _levelStateMachine;
    
        private void Awake()
        {
            _levelStateMachine = new LevelStateMachine();
            
            _levelStateMachine.EnterIn<LoadingLevelState>();
        }
    }
}
