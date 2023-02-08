using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class EffectBase
{
    #region Fields
    public List<GameObject> targets = new List<GameObject>();
    public float timeToTurnOff = 100f;
    #endregion

    #region Constructors
    public EffectBase(float timeToTurnOff)
    {
        this.timeToTurnOff = timeToTurnOff;
    }

    public EffectBase(List<GameObject> targets, float timeToTurnOff)
    {
        this.targets = targets;
        this.timeToTurnOff = timeToTurnOff;
    }
    #endregion
    
    public virtual async UniTask TurnOn() {
        foreach (GameObject target in targets)
        {
            TurnOnHandler(target);
        }
        
        await UniTask.Delay(TimeSpan.FromSeconds(timeToTurnOff));
        
        TurnOff();
    }

    public virtual void TurnOff()
    {
        foreach (GameObject target in targets)
        {
            TurnOffHandler(target);
        }
    }

    public abstract void TurnOnHandler(GameObject go);
    public abstract void TurnOffHandler(GameObject go);
}
