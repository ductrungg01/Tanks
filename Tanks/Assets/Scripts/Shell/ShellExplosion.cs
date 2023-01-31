﻿using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;       
    public AudioSource m_ExplosionAudio;              
    public float m_MaxDamage = 100f;                  
    public float m_ExplosionForce = 1000f;            
    public float m_MaxLifeTime = 2f;                  
    public float m_ExplosionRadius = 5f;              


    private void Start()
    {
        PoolManager.Instance.shellPooler.OnReturnToPool(gameObject, m_MaxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Find all the tanks in an area around the shell and damage them.
        
        m_ExplosionParticles.gameObject.SetActive(true);
        m_ExplosionParticles.gameObject.transform.position = this.transform.position;
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;
            
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
            
            if (!targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);

            if (damage != 0)
            {
                targetHealth.TakeDamage(damage);
            }
        }

        m_ExplosionParticles.transform.parent = null;
        
        m_ExplosionParticles.Play();
        
        m_ExplosionAudio.Play();
        
        PoolManager.Instance.shellPooler.OnReturnToPool(m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);
        PoolManager.Instance.shellPooler.OnReturnToPool(gameObject);
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        //float damage = relativeDistance * m_MaxDamage;
        float damage = relativeDistance * m_MaxDamage;

        damage = Mathf.Max(0f, damage);

        return damage;
    }
}