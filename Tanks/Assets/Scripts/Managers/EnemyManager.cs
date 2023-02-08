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
}
