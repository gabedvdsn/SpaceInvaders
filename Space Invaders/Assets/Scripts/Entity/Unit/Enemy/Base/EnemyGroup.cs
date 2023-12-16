using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class EnemyGroup
{
    private int ID;
    private List<Enemy> enemies;

    private IFormation formation;

    public EnemyGroup(int id, List<Enemy> enemies)
    {
        ID = id;
        this.enemies = enemies;
    }

}
