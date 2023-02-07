using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShellExplosion : Explosion 
{
    public float _MaxLifeTime = 2f;

    protected override void Start()
    {
        PoolManager.Instance.shellPooler.OnReturnToPool(gameObject, _MaxLifeTime);
    }

   
}