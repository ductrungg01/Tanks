using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownShooting : IShootingMethod
{
    public ShootingType _Type = ShootingType.Slowdown;
    private float _ForceBuffer = 1f;

    public ShootingType Type()
    {
        return _Type;
    }
    
    public void Fire(Vector3 position, Quaternion rotation, Vector3 velocity)
    {
        GameObject bullet = PoolManager.Instance.slowdownBulletPooler.OnTakeFromPool(position, rotation);
        PoolManager.Instance.slowdownBulletPooler.OnReturnToPool(bullet, 5.0f);

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
