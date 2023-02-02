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
        //Debug.Log("MachineGun fire");
        
        velocity = new Vector3(velocity.x, -0.5f, velocity.z);
        //rotation = Quaternion.Euler(10, rotation.y, rotation.z);
        
        velocity *= _ForceBuffer;

        GameObject bullet = PoolManager.Instance.rocketPooler.OnTakeFromPool(position, rotation);

        //bullet.transform.forward = velocity.normalized;

        Debug.Log(bullet.transform.forward);
            
        if (bullet)
        {
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            //bulletRb.AddForce(velocity * bulletRb.mass / Time.deltaTime);
            bulletRb.velocity = velocity;
        }
        else
        {
            Debug.Log("Error when creating the bullet");
        }
    }
}
