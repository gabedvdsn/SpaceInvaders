using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [Header("Space Sprites")]
    [SerializeField] private GameObject RSprite;
    [SerializeField] private GameObject CSprite;
    [SerializeField] private GameObject USprite;
    [SerializeField] private GameObject ULSprite;
    [SerializeField] private GameObject URSprite;
    [SerializeField] private GameObject DSprite;
    [SerializeField] private GameObject DRSprite;
    [SerializeField] private GameObject DLSprite;
    [SerializeField] private GameObject LSprite;

    [Header("Attributes")] 
    [SerializeField] private float width, height;

    // Update is called once per frame
    void Update()
    {
        
    }
}
