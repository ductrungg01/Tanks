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
    }

    protected override void TurnOff()
    {
        Destroy(gameObject.GetComponent<PoisonedEffectState>());
        
    }
}
