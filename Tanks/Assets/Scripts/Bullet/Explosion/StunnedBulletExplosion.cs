using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StunnedBulletExplosion : Explosion 
{
    protected override void Start()
    {
        PoolManager.Instance.rocketPooler.OnReturnToPool(gameObject, _MaxLifeTime);
        
        this._Effects.Add(new StunnedEffectBaseForEnemy(10));
    }

   
}