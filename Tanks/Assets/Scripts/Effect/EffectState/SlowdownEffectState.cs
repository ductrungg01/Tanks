using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowdownEffectState : EffectState
{
    public float slowdownSpeed;

    private Timer _timeToChangeSpeed;
    
    protected override void Start()
    {
        _timeToChangeSpeed = gameObject.AddComponent<Timer>();
        _timeToChangeSpeed.Duration = timeToTurnOff;
        _timeToChangeSpeed.Run();
        
        base.Start();
    }

    protected override void TurnOn()
    {
        gameObject.GetComponent<NavMeshAgent>().speed = slowdownSpeed;
    }

    protected override void TurnOff()
    {
        gameObject.GetComponent<NavMeshAgent>().speed = ConfigurationUtil.EnemyTankSpeed;
    }
}
