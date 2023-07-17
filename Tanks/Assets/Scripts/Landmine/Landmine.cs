using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Landmine : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject _ExplosionPrefab;

    private ParticleSystem _ExplosionParticles;
    private AudioSource _ExplosionAudio;
    #endregion
    
    void Start()
    {
        _ExplosionParticles = Instantiate(_ExplosionPrefab).GetComponent<ParticleSystem>();
        _ExplosionAudio = _ExplosionParticles.GetComponent<AudioSource>();
        
        _ExplosionParticles.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _ExplosionParticles.gameObject.SetActive(true);
        _ExplosionParticles.gameObject.transform.position = this.transform.position;
        
        TankHealth targetHealth = collision.gameObject.GetComponent<TankHealth>();

        if (targetHealth)
        {
            float damage = 30f;
            targetHealth.TakeDamage(damage);
            
            Rigidbody targetRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            targetRigidbody.AddExplosionForce(500f, transform.position, 1f);
            
            _ExplosionParticles.transform.parent = null;
        
            _ExplosionParticles.Play();
        
            _ExplosionAudio.Play();
            
            this.gameObject.SetActive(false);
        }
    }
}
