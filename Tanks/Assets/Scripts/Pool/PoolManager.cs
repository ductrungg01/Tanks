using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    
    public ObjectPooler shellPooler;
    public ObjectPooler rocketPooler;
    public ObjectPooler smokeGrenadePooler;
    public ObjectPooler icePooler;
    public ObjectPooler silentBulletPooler;
    public ObjectPooler stunnedBulletPooler;
    public ObjectPooler slowdownBulletPooler;
    public ObjectPooler stopBulletPooler;
    public ObjectPooler poisonedBulletPooler;

    private void Awake()
    {
        Instance = this;
    }
}
