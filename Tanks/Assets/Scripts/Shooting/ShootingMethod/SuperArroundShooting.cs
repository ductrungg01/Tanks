using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SuperArroundShooting : IShootingMethod
{
    public ShootingType _Type = ShootingType.SuperArround;

    private List<Vector3> pos = new List<Vector3>()
    {
        new Vector3(0, 1.7f, 1.35f),
        new Vector3(1.35f, 1.7f, 0),
        new Vector3(0f, 1.7f, -1.35f),
        new Vector3(-1.35f, 1.7f, 0)
    };

    private List<Quaternion> rot = new List<Quaternion>()
    {
        Quaternion.Euler(350, 0, 0),
        Quaternion.Euler(350, 90, 0),
        Quaternion.Euler(350, 180, 0),
        Quaternion.Euler(350, 270, 0),
    };

    private List<Vector3> velo = new List<Vector3>()
    {
        new Vector3(0, 2.0f, 15),
        new Vector3(15, 2.0f, 0),
        new Vector3(0, 2.0f, -15),
        new Vector3(-15, 2.0f, 0),
    };
    
    public ShootingType Type()
    {
        return _Type;
    }

    public void Fire(Vector3 position, Quaternion rotation, Vector3 velocity)
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject bullet = PoolManager.Instance.shellPooler.OnTakeFromPool(position + pos[i] + new Vector3(0, 0.5f, 0), rot[i]);
            PoolManager.Instance.shellPooler.OnReturnToPool(bullet, 5.0f);

            if (bullet)
            {
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.velocity = velo[i] * 1.5f;
            }
            else
            {
                Debug.Log("Error when creating the bullet");
            }
        }
    }
}
