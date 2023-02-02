using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    
    public ObjectPooler shellPooler;
    public ObjectPooler rocketPooler;

    private void Awake()
    {
        Instance = this;
    }
}
