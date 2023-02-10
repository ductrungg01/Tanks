using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectState : MonoBehaviour
{
    public float timeToTurnOff;
    
    protected Timer _interval;

    protected virtual void Start()
    {
        TurnOn();
        
        _interval = this.gameObject.AddComponent<Timer>();

        _interval.Duration = timeToTurnOff;
        _interval.Run();
    }

    protected virtual void Update()
    {
        if (_interval.Finished)
        {
            TurnOff();
        }
    }

    protected abstract void TurnOn();

    protected abstract void TurnOff();
}
