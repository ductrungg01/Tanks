using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PoisonedBulletExplosion : Explosion 
{
    protected override void Start()
    {
        PoolManager.Instance.poisonedBulletPooler.OnReturnToPool(gameObject, _MaxLifeTime);
        
        this._Effects.Add(new PoisonedEffectBaseForEnemy(10));
    }

   
}