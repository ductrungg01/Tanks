using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class RocketExplosion : Explosion
{
    private float _MaxLifeTime = 2f;

    protected override void Start()
    {
        PoolManager.Instance.rocketPooler.OnReturnToPool(gameObject, _MaxLifeTime);
        
        this.maxDamage = 50f;
        this._ExplosionForce = 20f;
        this._ExplosionRadius = 5f;
    }
}
