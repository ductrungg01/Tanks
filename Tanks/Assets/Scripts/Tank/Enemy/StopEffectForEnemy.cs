using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class StopEffectForEnemy : MonoBehaviour
{

    private void Start()
    {
        
    }

    public async UniTask TurnOn(float time)
    {
        gameObject.GetComponent<EnemyMoving>()._NavMeshAgent.speed = 0;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.GetComponent<EnemyShooting>().isStopShooting = true;
        
        await UniTask.Delay(TimeSpan.FromSeconds(time));
        
        TurnOff();
    }
    
    public void TurnOff()
    {
        gameObject.GetComponent<EnemyMoving>()._NavMeshAgent.speed = ConfigurationUtil.EnemyTankSpeed;
        gameObject.GetComponent<EnemyShooting>().isStopShooting = false;
    }
}
