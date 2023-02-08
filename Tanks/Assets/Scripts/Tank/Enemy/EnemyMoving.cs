using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    public NavMeshAgent _NavMeshAgent;
    private bool _IsStop = false;
    private bool _IsSlowdown = false;

    private void Start()
    {
        _NavMeshAgent.speed = ConfigurationUtil.EnemyTankSpeed;
    }

    private void Update()
    {
        if (IsStop)
        {
            _NavMeshAgent.speed = 0f;
        } 
        else if (IsSlowDown)
        {
            _NavMeshAgent.speed = 0.5f;
        }
        else
        {
            _NavMeshAgent.speed = ConfigurationUtil.EnemyTankSpeed;
        }
        
        _NavMeshAgent.SetDestination(GameManager.Instance._Player.transform.position);
    }

    public bool IsStop
    {
        get { return _IsStop; }
        set
        {
            _IsSlowdown = false;
            _IsStop = value;
        }
    }

    public bool IsSlowDown
    {
        get { return _IsSlowdown; }
        set
        {
            _IsStop = false;
            _IsSlowdown = value;
        }
    }
}
