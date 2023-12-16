using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Default Entity Attributes")]
    [SerializeField] protected GameElementClassification classification;
    [SerializeField] protected EntityAffiliation affiliation;
    
    // Components
    protected Animator anim;
    protected Rigidbody2D rb;
    
    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Update()
    {
        
    }
    
    #region Getters
    public virtual Entity Get() => this;
    public EntityAffiliation GetAffiliation() => affiliation;
    public GameElementClassification GetClassification() => classification;
    public Animator GetAnimator() => anim;
    public Rigidbody2D GetRB() => rb;
    #endregion
    
    #region Setters
    public void SetAffiliation(EntityAffiliation _affiliation) => affiliation = _affiliation;
    public void SetClassification(GameElementClassification _classification) => classification = _classification;
    #endregion
    
    #region Compare
    public bool CompareClassification(GameElementClassification _classification) => _classification == classification;
    public bool CompareAffiliation(EntityAffiliation _affiliation) => affiliation == _affiliation;
    
    #endregion
}
