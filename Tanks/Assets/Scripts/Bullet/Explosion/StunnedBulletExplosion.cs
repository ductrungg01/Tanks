using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StunnedBulletExplosion : Explosion 
{
    protected override void Start()
    {
        PoolManager.Instance.rocketPooler.OnReturnToPool(gameObject, _MaxLifeTime);

        this._Effects.Add(new SilentEffectBaseForEnemy(10f));
        this._Effects.Add(new StopEffectForEnemy(false, 10f));
    }

   
}