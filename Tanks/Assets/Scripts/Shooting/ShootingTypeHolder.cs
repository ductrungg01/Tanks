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
        }
        
        GameManager.Instance._Player.GetComponent<TankShooting>().typeInUse = type;
    }
}
