using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StopBulletExplosion : Explosion 
{
    protected override void Start()
    {
        PoolManager.Instance.rocketPooler.OnReturnToPool(gameObject, _MaxLifeTime);
        
        this._Effects.Add(new StopEffectBaseForEnemy(false, 10));
    }

   
}