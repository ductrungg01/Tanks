using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilentShooting : IShootingMethod
{
    public ShootingType _Type = ShootingType.Silent;
    private float _ForceBuffer = 1f;

    public ShootingType Type()
    {
        return _Type;
    }
    
    public void Fire(Vector3 position, Quaternion rotation, Vector3 velocity)
    {
        GameObject bullet = PoolManager.Instance.silentBulletPooler.OnTakeFromPool(position, rotation);
        PoolManager.Instance.silentBulletPooler.OnReturnToPool(bullet, 5.0f);

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
