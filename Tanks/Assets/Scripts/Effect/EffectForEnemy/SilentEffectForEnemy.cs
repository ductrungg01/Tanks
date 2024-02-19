using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SilentEffectBaseForEnemy : EffectBase
{
    #region Constructors
    public SilentEffectBaseForEnemy(float timeToTurnOff) : base(timeToTurnOff)
    {
    }

    public SilentEffectBaseForEnemy(List<GameObject> targets, float timeToTurnOff) : base(targets, timeToTurnOff)
    {
    }
    #endregion
    
    public override void TurnOnHandler(GameObject go)
    {
        go.GetComponent<EnemyShooting>().isStopShooting = true;
    }

    public override void TurnOffHandler(GameObject go)
    {
        go.GetComponent<EnemyShooting>().isStopShooting = true;
    }
}
