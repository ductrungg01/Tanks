using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Explosion : MonoBehaviour
{
    #region Fields
    public LayerMask _TankMask;
    public ParticleSystem _ExplosionParticles;       
    public AudioSource _ExplosionAudio;              
    public float maxDamage;                  
    public float _ExplosionForce = 0;
    public float _MaxLifeTime = 3f;
    public float _ExplosionRadius = 5f;

    public List<EffectSO> _Effects = new List<EffectSO>();
    #endregion

    protected abstract void Start();

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

            // Take damage
            #region Take damage
            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
            
            if (!targetHealth)
                continue;

            float damage = CalculateDamage.Calculate(
                new ExplosionInfor(this.transform.position, _ExplosionRadius, _ExplosionForce),
                targetRigidbody.position,
                maxDamage,
                DefendStat(colliders[i].gameObject)
            );

            if (damage != 0)
            {
                targetHealth.TakeDamage(damage);
            }
            #endregion
            
            // Do effects
            foreach (var e in _Effects)
            {
                // TODO: apply the effect for the targets
                //e.targets.Add(colliders[i].gameObject);
                //e.TurnOn(colliders[i].gameObject);
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
            PlayerStats playerStats = GameManager.Instance._Player.GetComponent<PlayerStats>();
            return playerStats.Defend;
        }
        else return 100;
    }
}
