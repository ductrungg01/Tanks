using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class RocketExplosion : MonoBehaviour
{
    #region Fields
    public LayerMask _TankMask;
    public ParticleSystem _ExplosionParticles;       
    public AudioSource _ExplosionAudio;              
    private float _MaxDamage = 50f;                  
    private float _ExplosionForce = 20f;            
    private float _MaxLifeTime = 2f;                  
    private float _ExplosionRadius = 2f;              
    #endregion

    private void Start()
    {
        PoolManager.Instance.rocketPooler.OnReturnToPool(gameObject, _MaxLifeTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Find all the tanks in an area around the shell and damage them.
        _ExplosionParticles.gameObject.SetActive(true);
        _ExplosionParticles.gameObject.transform.position = this.transform.position;
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, _ExplosionRadius, _TankMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;
            
            targetRigidbody.AddExplosionForce(_ExplosionForce, transform.position, _ExplosionRadius);

            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
            
            if (!targetHealth)
                continue;

            float damage = CalculateDamage.Calculate(
                new ExplosionInfor(this.transform.position, _ExplosionRadius, _ExplosionForce),
                targetRigidbody.position,
                _MaxDamage,
                DefendStat(colliders[i].gameObject)
            );

            if (damage != 0)
            {
                targetHealth.TakeDamage(damage);
            }
        }

        _ExplosionParticles.transform.parent = null;
        
        _ExplosionParticles.Play();
        
        _ExplosionAudio.Play();
        
        PoolManager.Instance.shellPooler.OnReturnToPool(_ExplosionParticles.gameObject, _ExplosionParticles.duration);
        PoolManager.Instance.shellPooler.OnReturnToPool(gameObject);
    }

    float DefendStat(GameObject go)
    {
        TankInformation infor = go.GetComponent<TankInformation>();

        if (infor._IsPlayer)
        {
            return PlayerStatsManager.Instance.Defend;
        }
        else return 100;
    }
}
