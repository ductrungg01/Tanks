using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperArroundShootingFireHandler : MonoBehaviour
{
    private void Start()
    {
        ShootingEventManager.Instance.AddListener(
            ShootingType.SuperArroundShooting, 
            Fire);
    }

    public void Fire()
    {
        Debug.Log("SuperArround is firing");
    }
}
