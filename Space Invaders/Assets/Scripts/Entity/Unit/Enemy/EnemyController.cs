using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Attributes
    private Enemy self;
    private GameObject target;

    // Instruction handling
    private EnemyInstructionType currentInstructionType;
    
    private EnemyInstructionType priorityInstructionType;
    private List<EnemyInstructionType> ignoreInstructionTypes;
    
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponentInParent<Enemy>();

        priorityInstructionType = EnemyInstructionType.None;
        ignoreInstructionTypes = new List<EnemyInstructionType>();
    }

    // Update is called once per frame
    void Update()
    {
        // AddVelocity(target.position - transform.position);
        ActOnInstruction();
    }

    #region Executing Instructions
    private void ActOnInstruction()
    {
        // Does not include internal instructions
        switch (currentInstructionType)
        {
            case EnemyInstructionType.GoAt:
                // self.AddVelocity();
                break;
            case EnemyInstructionType.StandbyAt:
                break;
            case EnemyInstructionType.AttackAt:
                break;
            case EnemyInstructionType.ProtectAt:
                break;
            case EnemyInstructionType.None:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    #endregion

    #region Receiving Instructions
    
    public void SendInstruction(EnemyInstructionType instructionType, EnemyInstruction instruction)
    {
        // To prioritize ProtectAt: SendInstruction(EnemyInstructionType.Prioritize, EnemyInstruction(entity, EnemyInstructionType.ProtectAt))

        if (ScreenInstruction(instructionType))
        {
            target = instruction.Get().gameObject;
            currentInstructionType = instructionType;
        }

        ExecuteInternalInstructions(instructionType, instruction);
    }
    
    private bool ScreenInstruction(EnemyInstructionType instructionType)
    {
        // Returns false for any type not priority, in ignore list, or is internal instruction
        
        if (ScreenInternalInstruction(instructionType)) return false;

        if (currentInstructionType != priorityInstructionType) return true;
        
        if (instructionType != priorityInstructionType && priorityInstructionType != EnemyInstructionType.None) return false;
        if (ignoreInstructionTypes.Contains(instructionType)) return false;

        return true;
    }

    private bool ScreenInternalInstruction(EnemyInstructionType instructionType) =>
        instructionType is EnemyInstructionType.PrioritizeAt or EnemyInstructionType.IgnoreAt or EnemyInstructionType.LevelStatus;

    private void ExecuteInternalInstructions(EnemyInstructionType instructionType, EnemyInstruction instruction)
    {
        switch (instructionType)
        {
            case EnemyInstructionType.PrioritizeAt:
                PrioritizeInstruction(instructionType);
                SendInstruction(instruction.Secondary(), instruction);
                break;
            case EnemyInstructionType.IgnoreAt:
                IgnoreInstruction(instructionType);
                SendInstruction(instruction.Secondary(), instruction);
                break;
            case EnemyInstructionType.LevelStatus:
                LevelInstruction(instructionType);
                break;
        }
    }
    
    private void PrioritizeInstruction(EnemyInstructionType instructionType)
    {
        LevelInstruction(instructionType);
        priorityInstructionType = instructionType;
    }
    private void ClearPriorityInstruction() => priorityInstructionType = EnemyInstructionType.None;

    private void IgnoreInstruction(EnemyInstructionType instructionType)
    {
        LevelInstruction(instructionType);
        ignoreInstructionTypes.Add(instructionType);
    }
    private void ClearIgnoreInstructions() => ignoreInstructionTypes.Clear();
    
    private void LevelInstruction(EnemyInstructionType instructionType)
    {
        ClearPriorityInstruction();
        ignoreInstructionTypes.Remove(instructionType);
    }
    private void LevelAllInstructions()
    {
        ClearPriorityInstruction();
        ClearIgnoreInstructions();
    }
    
    #endregion
    
}
