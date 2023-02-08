using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class StopEffectForEnemy : EffectBase
{
    private bool iceSpawn = false;
    
    
    public override void TurnOnHandler(GameObject go)
    {
        go.GetComponent<EnemyMoving>().IsStop = true;
        go.GetComponent<Rigidbody>().velocity = Vector3.zero;
        go.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        if (iceSpawn)
        {
            GameObject ice =
                PoolManager.Instance.icePooler.OnTakeFromPool(go.transform.position, go.transform.rotation);

            PoolManager.Instance.icePooler.OnReturnToPool(ice, timeToTurnOff);
        }
    }

    public override void TurnOffHandler(GameObject go)
    {
        go.GetComponent<EnemyMoving>().IsStop = false;
    }

    public StopEffectForEnemy(bool iceSpawn,float timeToTurnOff) : base(timeToTurnOff)
    {
        this.iceSpawn = iceSpawn;
    }

    public StopEffectForEnemy(bool iceSpawn, List<GameObject> targets, float timeToTurnOff) : base(targets, timeToTurnOff)
    {
        this.iceSpawn = iceSpawn;
    }
}
