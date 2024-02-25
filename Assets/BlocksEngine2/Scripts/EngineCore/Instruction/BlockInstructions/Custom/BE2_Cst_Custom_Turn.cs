using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- most used BE2 namespaces for instruction scripts 
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;

// --- additional BE2 namespaces used for specific cases as accessing BE2 variables or the event manager
// using MG_BlocksEngine2.Core;
// using MG_BlocksEngine2.Environment;

public class BE2_Cst_Custom_Turn : BE2_InstructionBase, I_BE2_Instruction
{
    public new bool ExecuteInUpdate => true;
    
    [SerializeField] private bool isLeftTurn;
    [SerializeField] private float speed = 4;
    
    private bool _canMove = true;
    private bool _canRotate;
    private float _timer;
    private Quaternion _targetRotation;
    private Vector3 _newDirection;
    
    public new void Function()
    {
        if (_canMove)
        {Debug.Log($"canMove {_canMove}");
            if (TargetObject is PlayerTarget target)
            {
                var eulerAngles = TargetObject.Transform.eulerAngles;
                _targetRotation = isLeftTurn ? Quaternion.Euler(eulerAngles.x, eulerAngles.y - 90, eulerAngles.z) : Quaternion.Euler(eulerAngles.x, eulerAngles.y + 90, eulerAngles.z);
                
                _timer = 2;
                _canRotate = true;
            }
            _canMove = false;
        }

        if (_canRotate)
        {
            TargetObject.Transform.rotation = Quaternion.Slerp(TargetObject.Transform.rotation, _targetRotation, speed * Time.deltaTime);
        }
        
        
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            TargetObject.Transform.rotation = _targetRotation;
            _timer = 0;
            _canMove = false;
            _canRotate = false;
            ExecuteNextInstruction();
        }
    }

    // ### Execution Setting ###

    // --- Use ExecuteInUpdate for functions that plays repeatedly in update, holding the blocks stack execution flow until completed (ex.: wait, lerp).
    // --- Default value is false. Loop Blocks are always executed in update (true).
    //public new bool ExecuteInUpdate => true; 

    // ### Additional Methods ###

    // --- executed on button stop pressed
    protected override void OnButtonStop()
    {
        _canMove = true;
        _timer = 0;
    }
    
    // --- executed on the stack transition from deactive to active
    public override void OnStackActive()
    {
        _canMove = true;
        _timer = 0;
    }
}
