using UnityEngine;

namespace FSM
{
    public class LevelInstance : MonoBehaviour
    {
        [SerializeField] private LevelSettings level_1;
        [SerializeField] private LevelSettings level_2;
        
        private LevelStateMachine _levelStateMachine;
        
        private void Awake()
        {
            _levelStateMachine = new LevelStateMachine();
            
            _levelStateMachine.EnterIn<LoadingLevelState>();
        }
    }
}
