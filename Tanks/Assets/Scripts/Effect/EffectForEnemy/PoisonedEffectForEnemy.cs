using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PoisonedEffectBaseForEnemy : EffectBase
{
    #region Constructors
    public PoisonedEffectBaseForEnemy(float timeToTurnOff) : base(timeToTurnOff)
    {
    }

    public PoisonedEffectBaseForEnemy(List<GameObject> targets, float timeToTurnOff) : base(targets, timeToTurnOff)
    {
    }
    #endregion
    
    public override void TurnOnHandler(GameObject go)
    {
        TankHealth.PoisonedInfor poisonedInfor = new TankHealth.PoisonedInfor();
        poisonedInfor._TimesOfPoisoned = 10;
        poisonedInfor._PoisonedDamage = 5;

        go.GetComponent<TankHealth>().SetIsPoisoned();
        go.GetComponent<TankHealth>()._PoisonedInfor = poisonedInfor;
    }

    public override void TurnOffHandler(GameObject go)
    {
        go.GetComponent<TankHealth>().SetIsPoisoned(false);
    }


}
