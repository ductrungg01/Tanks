using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class StopEffectForEnemy : EffectBase
{
    private bool iceSpawn = false;

    #region Constructors
    public StopEffectForEnemy(bool iceSpawn,float timeToTurnOff) : base(timeToTurnOff)
    {
        this.iceSpawn = iceSpawn;
    }

    public StopEffectForEnemy(bool iceSpawn, List<GameObject> targets, float timeToTurnOff) : base(targets, timeToTurnOff)
    {
        this.iceSpawn = iceSpawn;
    }
    #endregion
    
    public override void TurnOnHandler(GameObject go)
    {
        go.GetComponent<EnemyMoving>().IsStop = true;
        go.GetComponent<Rigidbody>().velocity = Vector3.zero;
        go.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        if (iceSpawn)
        {
            Vector3 iceOffsetPos = new Vector3(-1f, 2f, -1f);
            
            GameObject ice =
                PoolManager.Instance.icePooler.OnTakeFromPool(go.transform.position + iceOffsetPos, Quaternion.Euler(0, 250, 0));

            PoolManager.Instance.icePooler.OnReturnToPool(ice, timeToTurnOff);
        }
    }

    public override void TurnOffHandler(GameObject go)
    {
        go.GetComponent<EnemyMoving>().IsStop = false;
    }
}
