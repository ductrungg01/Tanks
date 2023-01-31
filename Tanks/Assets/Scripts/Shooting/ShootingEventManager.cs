using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingEventManager : MonoBehaviour
{
    public static ShootingEventManager Instance;

    private RocketFireEvent _RocketFireEvent = new RocketFireEvent();
    private MachineGunFireEvent _MachineGunFireEvent = new MachineGunFireEvent();
    private SmokeGrenadeFireEvent _SmokeGrenadeFireEvent = new SmokeGrenadeFireEvent();
    private SuperArroundShootingFireEvent _SuperArroundShootingFireEvent = new SuperArroundShootingFireEvent();
    
    private void Awake()
    {
        Instance = this;
    }

    public void AddListener(ShootingType shootingType, UnityAction listener)
    {
        switch (shootingType)
        {
            case ShootingType.Rocket:
            {
                _RocketFireEvent.AddListener(listener);
                break;
            }
            case ShootingType.MachineGun:
            {
                _MachineGunFireEvent.AddListener(listener);
                break;
            }
            case ShootingType.SmokeGrenade:
            {
                _SmokeGrenadeFireEvent.AddListener(listener);
                break;
            }
            case ShootingType.SuperArroundShooting:
            {
                _SuperArroundShootingFireEvent.AddListener(listener);
                break;
            }
        }
    }

  
    
    public void InvokeEvent(ShootingType shootingType)
    {
        switch (shootingType)
        {
            case ShootingType.Rocket:
            {
                _RocketFireEvent.Invoke();
                break;
            }
            case ShootingType.MachineGun:
            {
                _MachineGunFireEvent.Invoke();
                break;
            }
            case ShootingType.SmokeGrenade:
            {
                _SmokeGrenadeFireEvent.Invoke();
                break;
            }
            case ShootingType.SuperArroundShooting:
            {
                _SuperArroundShootingFireEvent.Invoke();
                break;
            }
        }
    }
}
