using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SlowdownEffectBaseForEnemy : EffectBase
{
    #region Constructors
    public SlowdownEffectBaseForEnemy(float timeToTurnOff) : base(timeToTurnOff)
    {
    }

    public SlowdownEffectBaseForEnemy(List<GameObject> targets, float timeToTurnOff) : base(targets, timeToTurnOff)
    {
    }
    #endregion
    
    public override void TurnOnHandler(GameObject go)
    {
        go.GetComponent<EnemyMoving>().IsSlowDown = true;
    }

    public override void TurnOffHandler(GameObject go)
    {
        go.GetComponent<EnemyMoving>().IsSlowDown = false;
    }
}
