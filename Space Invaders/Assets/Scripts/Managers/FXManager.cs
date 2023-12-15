using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class FXManager : ObservableSubject
{
    // Ship FX
    [SerializeField] private GameObject shipExplosionFX;
    
    // Explosion FX
    [SerializeField] private GameObject[] allExplosionFX;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            position.z = 0;

            CreateManyRandomExplosions(position, 3, 5, .5f, .5f);
        }
    }
    #region Helpers
    
    private GameObject CreateFXObject(GameObject FXObject, Vector2 position, Quaternion rotation) => Instantiate(FXObject, position, rotation);

    private float GetWaitDuration(float timeBetween, float timeBetweenVariation) => Mathf.Abs(timeBetween + timeBetweenVariation * Random.value * Mathf.Sign(Random.value - .5f));
    
    #endregion
    
    #region Coroutines
    
    IEnumerator CreateManyFXDelayed(GameObject FXObject, Vector2 midpoint, int radius, int amount, float timeBetween, float timeBetweenVariation = 0f)
    {
        if (amount <= 0) yield break;
        
        // Generate FX Object
        float r = radius * Mathf.Sqrt(Random.value);
        float theta = Random.value * 2 * Mathf.PI;

        Vector2 position = new Vector2(midpoint.x + r * Mathf.Cos(theta), midpoint.y + r * Mathf.Sin(theta));

        CreateFXObject(FXObject, position, Quaternion.identity);
            
        // Calculate next timing
        float waitDuration = GetWaitDuration(timeBetween, timeBetweenVariation);
        yield return new WaitForSeconds(waitDuration);
            
        // Call next timing
        StartCoroutine(CreateManyFXDelayed(FXObject, midpoint, radius, amount - 1, timeBetween, timeBetweenVariation));
    }

    IEnumerator CreateManyRandoMFXDelayed(GameObject[] FXObjectArr, Vector2 midpoint, int radius, int amount, float timeBetween, float timeBetweenVariation = 0f)
    {
        if (amount <= 0) yield break;
        
        // Determine FX Object (index)
        int FXIndex = Random.Range(0, FXObjectArr.Length);
        
        // Generate FX Object
        StartCoroutine(CreateManyFXDelayed(FXObjectArr[FXIndex], midpoint, radius, 1, timeBetween, timeBetweenVariation));
        
        // Calculate next timing
        float waitDuration = GetWaitDuration(timeBetween, timeBetweenVariation);
        yield return new WaitForSeconds(waitDuration);
        
        // Call next timing
        StartCoroutine(CreateManyRandoMFXDelayed(FXObjectArr, midpoint, radius, amount - 1, timeBetween, timeBetweenVariation));


    }
    
    #endregion
    
    #region Ship FX
    
    public void CreateShipExplosion(Vector2 position) => CreateFXObject(shipExplosionFX, position, Quaternion.identity);
    public void CreateManyShipExplosions(Vector2 midpoint, int radius, int amount, float timeBetween, float timeBetweenVariation = 0f) => 
        StartCoroutine(CreateManyFXDelayed(shipExplosionFX, midpoint, radius, amount, timeBetween, timeBetweenVariation));
    
    #endregion
    
    #region Explosion FX
    public void CreateRandomExplosion(Vector2 position) => CreateFXObject(allExplosionFX[Random.Range(0, allExplosionFX.Length)], position, Quaternion.identity);

    public void CreateManyRandomExplosions(Vector2 midpoint, int radius, int amount, float timeBetween, float timeBetweenVariation = 0f) =>
        StartCoroutine(CreateManyRandoMFXDelayed(allExplosionFX, midpoint, radius, amount, timeBetween, timeBetweenVariation));

    #endregion
}
