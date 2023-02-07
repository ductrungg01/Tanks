using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SilentBulletExplosion : Explosion 
{
    protected override void Start()
    {
        PoolManager.Instance.rocketPooler.OnReturnToPool(gameObject, _MaxLifeTime);
        
        this._Effects.Add(new SilentEffectBaseForEnemy(10));
    }

   
}