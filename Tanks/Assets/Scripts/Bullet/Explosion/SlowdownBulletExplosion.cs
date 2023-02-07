using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SlowdownBulletExplosion : Explosion
{
    protected override void Start()
    {
        PoolManager.Instance.rocketPooler.OnReturnToPool(gameObject, _MaxLifeTime);
        
        this._Effects.Add(new SlowdownEffectBaseForEnemy(10));
    }

   
}