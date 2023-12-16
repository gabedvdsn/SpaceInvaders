using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : Entity
{
    [SerializeField] public float idleRotationSpeed;
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        
        DoIdleRotation();
    }

    void DoIdleRotation() => transform.Rotate(0, 0, idleRotationSpeed * Time.deltaTime);
}
