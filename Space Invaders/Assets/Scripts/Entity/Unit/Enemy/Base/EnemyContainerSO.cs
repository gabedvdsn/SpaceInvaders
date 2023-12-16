using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainerSO : ScriptableObject
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private GameObject enemyPrefab;
    
    public EnemyData GetData() => enemyData;
    public GameObject GetPrefab() => enemyPrefab;
}
