using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    
    public List<Transform> SpawnPointPositions = new List<Transform>();

    public List<GameObject> EnemyInstance = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    public void StopEffectAllEnemy(float time)
    {
        foreach (GameObject enemy in EnemyInstance)
        {
            StopEffectForEnemy stopEffect = enemy.GetComponent<StopEffectForEnemy>();
            stopEffect.TurnOn(time);
        }
    }
}
