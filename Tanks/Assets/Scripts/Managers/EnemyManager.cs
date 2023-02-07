using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyManager : MonoBehaviour
{
    #region Fields
    public static EnemyManager Instance;
    
    public List<Transform> SpawnPointPositions = new List<Transform>();

    [HideInInspector] public List<GameObject> EnemyInstanceList = new List<GameObject>();
    #endregion

    private void Awake()
    {
        Instance = this;
    }

    // public void StopEffectAllEnemy(float time, bool spawnTheIce = false)
    // {
    //     foreach (GameObject enemy in EnemyInstance)
    //     {
    //         StopEffectForEnemy stopEffect = enemy.GetComponent<StopEffectForEnemy>();
    //         stopEffect.TurnOn(time);
    //
    //         if (spawnTheIce == true)
    //         {
    //             GameObject ice = PoolManager.Instance.icePooler.OnTakeFromPool(
    //                 enemy.transform.position + new Vector3(-1f, 0.8f, -1.5f), 
    //                 Quaternion.Euler(0, 55, 0));
    //             PoolManager.Instance.icePooler.OnReturnToPool(ice, time);
    //         }
    //     }
    // }
}
