using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    [SerializeField] private string animBoolName;

    private void Awake()
    {
        GetComponent<Animator>().SetBool(animBoolName, true);
    }
    
    public void DestroyTrigger() => Destroy(gameObject);
}
