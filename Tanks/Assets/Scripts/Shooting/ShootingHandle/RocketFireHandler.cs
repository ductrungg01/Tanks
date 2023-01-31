using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFireHandler : MonoBehaviour
{
    private void Start()
    {
        ShootingEventManager.Instance.AddListener(ShootingType.Rocket, Fire);
    }

    public void Fire()
    {
        Debug.Log("Rocket is firing");
    }
}
