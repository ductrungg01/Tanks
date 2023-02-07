using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class StunnedEffectBaseForEnemy : EffectBase
{
    public override void TurnOnHandler(GameObject go)
    {
        go.GetComponent<EnemyShooting>().isStopShooting = true;
        go.GetComponent<EnemyMoving>().IsStop = true;
    }

    public override void TurnOffHandler(GameObject go)
    {
        go.GetComponent<EnemyShooting>().isStopShooting = false;
        go.GetComponent<EnemyMoving>().IsStop = false;
    }

    public StunnedEffectBaseForEnemy(float timeToTurnOff) : base(timeToTurnOff)
    {
    }

    public StunnedEffectBaseForEnemy(List<GameObject> targets, float timeToTurnOff) : base(targets, timeToTurnOff)
    {
    }
}
