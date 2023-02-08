using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingTypeHolder : MonoBehaviour
{
    public Button startingType;

    private void Start()
    {
        startingType.onClick.Invoke();
    }

    public void ChangeType(int typeIndex)
    {
        ShootingType type = ShootingType.Rocket;
        switch (typeIndex)
        {
            case 1:
            {
                type = ShootingType.Rocket;
                break;
            }
            case 2:
            {
                type = ShootingType.MachineGun;
                break;
            }
            case 3:
            {
                type = ShootingType.SmokeGrenade;
                break;
            }
            case 4:
            {
                type = ShootingType.SuperArround;
                break;
            }
            case 5:
            {
                type = ShootingType.Silent;
                break;
            }
            case 6:
            {
                type = ShootingType.Stunned;
                break;
            }
            case 7:
            {
                type = ShootingType.Slowdown;
                break;
            }
            case 8:
            {
                type = ShootingType.Stop;
                break;
            }
            case 9:
            {
                type = ShootingType.Poisoned;
                break;
            }
        }
        
        
        
        GameManager.Instance._Player.GetComponent<TankShooting>().typeInUse = type;
    }
}
