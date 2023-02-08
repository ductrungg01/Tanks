using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class RocketExplosion : Explosion
{
    protected override void Start()
    {
        this.maxDamage = 5f;
        this._ExplosionForce = 5f;
        this._MaxLifeTime = 3f;
        this._ExplosionRadius = 5f;
        
        PoolManager.Instance.rocketPooler.OnReturnToPool(gameObject, _MaxLifeTime);
    }
}
