using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShellExplosion : Explosion 
{
    protected override void Start()
    {
        this.maxDamage = 100f;
        this._ExplosionForce = 1000f;
        this._MaxLifeTime = 3f;
        this._ExplosionRadius = 5f;
        
        PoolManager.Instance.shellPooler.OnReturnToPool(gameObject, _MaxLifeTime);
        
        
    }

   
}