using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SmokeGrenadeShooting : IShootingMethod
{
    public ShootingType _Type = ShootingType.SmokeGrenade;
    public ShootingType Type()
    {
        return _Type;
    }

    public void Fire(Vector3 position, Quaternion rotation, Vector3 velocity)
    {
        GameObject bullet = PoolManager.Instance.smokeGrenadePooler.OnTakeFromPool(position, rotation);
        PoolManager.Instance.shellPooler.OnReturnToPool(bullet, 5.0f);

        if (bullet)
        {
            SmokeGrenadeExplosion bulletExp = bullet.GetComponent<SmokeGrenadeExplosion>();
            bulletExp.TurnOn();
            StopEffectForEnemy stopEffectForEnemy = new StopEffectForEnemy(false, EnemyManager.Instance.EnemyInstanceList, 10);
            stopEffectForEnemy.TurnOn();
        }
        else
        {
            Debug.Log("Error when creating the bullet");
        }
    }
}
