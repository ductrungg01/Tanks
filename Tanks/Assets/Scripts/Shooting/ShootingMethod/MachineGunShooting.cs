using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunShooting : IShootingMethod
{
    public ShootingType _Type = ShootingType.MachineGun;
    private float _ForceBuffer = 5f;

    public ShootingType Type()
    {
        return _Type;
    }

    public void Fire(Vector3 position,Quaternion rotation, Vector3 velocity)
    {
        velocity = new Vector3(velocity.x, -0.5f, velocity.z);
        velocity *= _ForceBuffer;

        GameObject bullet = PoolManager.Instance.rocketPooler.OnTakeFromPool(position, rotation);

        if (bullet)
        {
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = velocity;
        }
        else
        {
            Debug.Log("Error when creating the bullet");
        }
    }
}
