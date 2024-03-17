using UnityEngine;
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Core;

public class BE2_Cst_Custom_Move : BE2_InstructionBase, I_BE2_Instruction
{
    [SerializeField] private float speed = 150;
    
    public new bool ExecuteInUpdate => true;

    private bool _canMove = true;
    private Transform _targetPoint;
    private Vector3 _velocity = Vector3.zero;
    private float _timer;

    // ### Execution Methods ###

    // --- Method used to implement Function Blocks (will only be called by types: simple, condition, loop, trigger)
    public new void Function()
    {
        if (_canMove)
        {
            if (TargetObject is PlayerTarget target)
            {
                if (target.CheckWall())
                {
                    Debug.Log($"Обнаружил стену");
                    BE2_ExecutionManager.Instance.Stop();
                    return;
                }
                
                var platformTarget = target?.PathChecker.CrateRay();
                
                if (platformTarget is null)
                {
                    _canMove = false;
                    return;
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
          //  TargetObject.Transform.position = _targetPoint.position;
            _targetPoint = null;
            ExecuteNextInstruction();
        }
    }

    // ### Execution Setting ###

    // --- Use ExecuteInUpdate for functions that plays repeatedly in update, holding the blocks stack execution flow until completed (ex.: wait, lerp).
    // --- Default value is false. Loop Blocks are always executed in update (true).
    //public new bool ExecuteInUpdate => true; 

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
