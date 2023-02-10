using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopShooting : IShootingMethod
{
    private float _ForceBuffer = 1f;

    public void Fire(Vector3 position, Quaternion rotation, Vector3 velocity)
    {
        GameObject bullet = PoolManager.Instance.stopBulletPooler.OnTakeFromPool(position, rotation);
        PoolManager.Instance.stopBulletPooler.OnReturnToPool(bullet, 5.0f);

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
