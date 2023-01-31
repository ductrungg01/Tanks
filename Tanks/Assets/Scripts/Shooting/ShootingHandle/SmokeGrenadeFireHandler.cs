using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeGrenadeFireHandler : MonoBehaviour
{
    private void Start()
    {
        ShootingEventManager.Instance.AddListener(ShootingType.MachineGun, Fire);
    }

    public void Fire()
    {
        Debug.Log("SmokeGrenade is firing");
    }
}
