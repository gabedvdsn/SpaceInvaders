using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class AggroBehaviour
{
    /// <summary>
    /// AggroBehaviour defines who and what a unit will attack
    /// AggroBehaviour defines when a unit will change targets
    /// AggroBehaviour defines how a unit will respond to certain events
    /// </summary>
    
    [SerializeField] private GameElementClassification[] canTargetClassifications;
    [SerializeField] private EntityAffiliation[] canTargetAffiliations;
    [Space] 
    [SerializeField] private float aggroRadius;
    [Header("Before Aggro Attributes")]
    [SerializeField] private float toAggroThreshold;
    [SerializeField] private float preAggroDrainRate;
    [SerializeField] private float preAggroDrainTimerDuration;

    [Space] [Header("After Aggro Attributes")] 
    [SerializeField] private float onAggroAdditiveAmount;
    [SerializeField] private float postAggroDrainRate;
    [SerializeField] private float postAggroDrainTimerDuration;

    public float GetAggroRadius() => aggroRadius;
    public float GetAggroThreshold() => toAggroThreshold;
    public float GetPreAggroDrainRate() => preAggroDrainRate;
    public float GetPreAggroDrainTimerDuration() => preAggroDrainTimerDuration;

    public float GetOnAggroAdditiveAmount() => onAggroAdditiveAmount;
    public float GetPostAggroDrainRate() => postAggroDrainRate;
    public float GetPostAggroDrainTimerDuration() => postAggroDrainTimerDuration;
    
    public bool IsValidTargetClassification(GameElementClassification classification) => canTargetClassifications.Contains(classification) || classification == GameElementClassification.Any;
    public bool IsValidTargetAffiliation(EntityAffiliation affiliation, EntityAffiliation parentAffiliation)
    {
        /*if (affiliation == parentAffiliation) return false;
        if (canTargetAffiliations.Contains(EntityAffiliation.Any)) return true;
        Debug.Log($"(false) AFF is PARENT AFF {affiliation == parentAffiliation}");
        Debug.Log($"(true) AFF is TARGETABLE AFF {canTargetAffiliations.Contains(affiliation)}");
        Debug.Log($"(true) AFF is ANY {affiliation == EntityAffiliation.Any}");*/
        
        
        return affiliation != parentAffiliation && 
               (canTargetAffiliations.Contains(EntityAffiliation.Any) || canTargetAffiliations.Contains(affiliation) || affiliation == EntityAffiliation.Any);
    }

}
