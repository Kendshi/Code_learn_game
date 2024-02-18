using System.Collections;
using UnityEngine;

using MG_BlocksEngine2.Block.Instruction;

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
            { _targetPoint = target?.CheckPath();
                var distance = Vector3.Distance(TargetObject.Transform.position, _targetPoint.position); 
                _timer = distance / speed * 100;
            }
            _canMove = false;
        }
        
        if (_targetPoint)
        {
          TargetObject.Transform.position = Vector3.SmoothDamp(TargetObject.Transform.position, _targetPoint.position, ref _velocity, speed * Time.deltaTime);  
        }
        
       
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _timer = 0;
            ExecuteNextInstruction();
            _canMove = false;
            _targetPoint = null;
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
