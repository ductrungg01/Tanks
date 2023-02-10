using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonedEffectState : EffectState
{
    public float durationTime;
    private Timer _duration;
    public float damage;
    
    protected override void Start()
    {
        base.Start();

        _duration = this.gameObject.AddComponent<Timer>();
        _duration.Duration = durationTime;
        _duration.Run();
    }

    protected override void Update()
    {
        Debug.Log("PoisonEffect time remain: " + _interval.SecondsLeft);
        
        if (_duration.Finished)
        {
            TurnOn();
            _duration.Stop();
            _duration.Run();
        }
        
        base.Update();
    }

    protected override void TurnOn()
    {
        this.gameObject.GetComponent<TankHealth>().TakeDamage(damage);
        
        Debug.Log("PoisonEffect: ON");
    }

    protected override void TurnOff()
    {
        Debug.Log("PoisonEffect: OFF");
        Destroy(gameObject.GetComponent<PoisonedEffectState>());
        
    }
}
