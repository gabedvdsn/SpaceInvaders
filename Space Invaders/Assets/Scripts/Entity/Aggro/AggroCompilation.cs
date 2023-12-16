using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AggroCompilation : MonoBehaviour
{
    [SerializeField] private AggroBehaviour behaviour;

    private EntityAffiliation parentAffiliation;

    [Header("READ ONLY - Aggro Attributes")]
    [SerializeField] private bool hasAggro;
    [SerializeField] private float currentAggro;
    [SerializeField] private GameObject aggroTarget;
    [SerializeField] private float drainTimer;

    [SerializeField] private bool waitForDrainTimer;
    [SerializeField] private bool aggroTargetInAggroRange;
    
    // Start is called before the first frame update
    private void Start()
    {
        parentAffiliation = GetComponentInParent<Entity>().GetAffiliation();
        GetComponent<CircleCollider2D>().radius = behaviour.GetAggroRadius();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!ShouldRunUpdate()) return;
        
        if (waitForDrainTimer)  // got aggro recently - waiting for aggro timer to complete
        {
            DoDrainTimer();
        }
        else  // count down current aggro until 0
        {
            DrainCurrentAggro(hasAggro ? behaviour.GetPostAggroDrainRate() : behaviour.GetPreAggroDrainRate());
        }
    }

    public bool HasAggro() => hasAggro;
    public float GetCurrentAggro() => currentAggro;

    private bool ShouldRunUpdate() => !aggroTargetInAggroRange && (currentAggro > 0 || waitForDrainTimer);

    private void OnTriggerEnter2D(Collider2D other)
    {
        Entity entity = other.GetComponent<Entity>();

        if (entity is null) return;

        if (ConsiderEntityForAggro(entity))
        {
            if (!aggroTargetInAggroRange) AccrueAggro(entity);
            if (aggroTarget == other.gameObject) aggroTargetInAggroRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == aggroTarget) aggroTargetInAggroRange = false;
    }

    private bool ConsiderEntityForAggro(Entity entity)
    {
        Debug.Log(entity.name);
        
        return behaviour.IsValidTargetAffiliation(entity.Get().GetAffiliation(), parentAffiliation) && // can this entity aggro against this affiliation? (ally/enemy)
               behaviour.IsValidTargetClassification(entity.Get().GetClassification());  // can this entity aggro against this classification (ship/structure)
    }

    private void AccrueAggro(Entity entity)
    {
        currentAggro += EntityAggroDefaults.FromClassification(entity.GetClassification());

        ResetDrainTimer(hasAggro ? behaviour.GetPostAggroDrainTimerDuration() : behaviour.GetPreAggroDrainTimerDuration());

        if (hasAggro)
        {
            if (ShouldDeactivateAggro()) DeactivateAggro();
        }
        else
        {
            if (ShouldActivateAggro()) ActivateAggro(entity);
        }
    }

    private bool ShouldActivateAggro() => currentAggro >= behaviour.GetAggroThreshold();
    
    private void ActivateAggro(Entity entity)
    {
        hasAggro = true;
        aggroTarget = entity.Get().gameObject;

        drainTimer += behaviour.GetOnAggroAdditiveAmount();
        currentAggro += behaviour.GetOnAggroAdditiveAmount();

        if (Vector2.Distance(aggroTarget.transform.position, transform.position) <= behaviour.GetAggroRadius()) aggroTargetInAggroRange = true;
    }
    
    private bool ShouldDeactivateAggro() => currentAggro <= 0;

    private void DeactivateAggro()
    {
        hasAggro = false;
        currentAggro = 0;
        aggroTarget = null;
    }

    private void DoDrainTimer()
    {
        if (drainTimer <= 0)
        {
            waitForDrainTimer = false;
            drainTimer = 0;
            return;
        }
        
        drainTimer -= Time.deltaTime;
    }

    private void ResetDrainTimer(float amount)
    {
        waitForDrainTimer = true;
        
        drainTimer = amount;
    }

    private void DrainCurrentAggro(float amount)
    {
        currentAggro -= amount * Time.deltaTime;

        if (!(currentAggro <= 0)) return;
        
        currentAggro = 0;
        if (hasAggro) DeactivateAggro();
    }

}
