using UnityEngine;
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Core;
using UnityEngine.SceneManagement;

public class BE2_Cst_Custom_Move : BE2_InstructionBase, I_BE2_Instruction
{
    [SerializeField] private float speed = 150;
    
    public new bool ExecuteInUpdate => true;

    private bool _canMove = true;
    private bool _isFinishPlatform;
    private Transform _targetPoint;
    private float _timer;
    

    // ### Execution Methods ###

    // --- Method used to implement Function Blocks (will only be called by types: simple, condition, loop, trigger)
    public new void Function()
    {
        if (_canMove)
        {
            if (TargetObject is PlayerTarget target)
            {
                var platformTarget = target?.PathChecker.CrateRay();
                
                if (target.CheckWall() || platformTarget is null || !target.IsNotHigh())
                {
                    BE2_ExecutionManager.Instance.Stop();
                    return;
                }

                if (platformTarget.IsThisFinish())
                {
                    _isFinishPlatform = true;
                }

                _targetPoint = platformTarget.NavPoint;
                var distance = Vector3.Distance(TargetObject.Transform.position, _targetPoint.position); 
                _timer = distance / (speed);
                Debug.Log($"Время на перемещение: {_timer} расстояние: {distance}  скорость: {speed}");
            }
            _canMove = false;
        }
        
        if (_targetPoint)
        {
            TargetObject.Transform.position = Vector3.MoveTowards(TargetObject.Transform.position, _targetPoint.position, speed * Time.deltaTime); 
        }
        
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _timer = 0;
            _canMove = false;
            TargetObject.Transform.position = _targetPoint.position;
            _targetPoint = null;
            if (_isFinishPlatform)
            {
                _isFinishPlatform = false;
                BE2_ExecutionManager.Instance.Stop();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }
            ExecuteNextInstruction();
        }
    }

    // ### Additional Methods ###
    
    public override void OnStackActive()
    {
        _canMove = true;
        _timer = 0;
    }
    
    protected override void OnButtonStop()
    {
        _canMove = true;
        _timer = 0;
    }
}
