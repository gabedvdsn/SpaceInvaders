using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Managers : MonoBehaviour
{
    public static Managers Instance;

    [HideInInspector] public GameManager GameManager;
    [HideInInspector] public PlayerInputManager PlayerInputManager;
    [HideInInspector] public AudioManager AudioManager;
    [HideInInspector] public FXManager FXManager;
    [HideInInspector] public EnemyManager EnemyManager;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance is not null || Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;

            GameManager = GetComponentInChildren<GameManager>();
            PlayerInputManager = GetComponentInChildren<PlayerInputManager>();
            AudioManager = GetComponentInChildren<AudioManager>();
            FXManager = GetComponentInChildren<FXManager>();
            EnemyManager = GetComponentInChildren<EnemyManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
