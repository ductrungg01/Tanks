using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StopEffectState : EffectState
{
    protected override void TurnOn()
    {
        this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
    }

    protected override void TurnOff()
    {
        this.gameObject.GetComponent<NavMeshAgent>().speed = ConfigurationUtil.EnemyTankSpeed;

        Destroy(gameObject.GetComponent<StopEffectState>());
    }


}
