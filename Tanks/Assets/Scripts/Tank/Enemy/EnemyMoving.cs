using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    public NavMeshAgent _NavMeshAgent;

    private void Start()
    {
        _NavMeshAgent.speed = ConfigurationUtil.EnemyTankSpeed;
    }

    private void Update()
    {
        _NavMeshAgent.SetDestination(GameManager.Instance._Player.transform.position);
    }
}
