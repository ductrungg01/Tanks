using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SmokeGrenadeShooting : IShootingMethod
{
    public void Fire(Vector3 position, Quaternion rotation, Vector3 velocity)
    {
        GameObject bullet = PoolManager.Instance.smokeGrenadePooler.OnTakeFromPool(position, rotation);
        PoolManager.Instance.shellPooler.OnReturnToPool(bullet, 5.0f);

        if (bullet)
        {
            SmokeGrenadeExplosion bulletExp = bullet.GetComponent<SmokeGrenadeExplosion>();
            bulletExp.TurnOn();
            
            // TODO: add effect for all enemy instead of add oll enemy for effect
            // StopEffect stopEffectForEnemy = new StopEffect( EnemyManager.Instance.EnemyInstanceList, 10);
            // stopEffectForEnemy.TurnOn();
        }
        else
        {
            Debug.Log("Error when creating the bullet");
        }
    }
}
