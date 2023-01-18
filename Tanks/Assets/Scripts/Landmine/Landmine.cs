using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Landmine : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;

    private ParticleSystem _explosionParticles;
    private AudioSource _explosionAudio;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _explosionParticles = Instantiate(_explosionPrefab).GetComponent<ParticleSystem>();
        _explosionAudio = _explosionParticles.GetComponent<AudioSource>();

        _explosionParticles.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        _explosionParticles.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        _explosionParticles.gameObject.SetActive(true);
        _explosionParticles.gameObject.transform.position = this.transform.position;
        
        TankHealth targetHealth = collision.gameObject.GetComponent<TankHealth>();

        if (targetHealth)
        {
            float damage = 30f;
            targetHealth.TakeDamage(damage);
            
            Rigidbody targetRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            targetRigidbody.AddExplosionForce(500f, transform.position, 1f);
            
            _explosionParticles.transform.parent = null;
        
            _explosionParticles.Play();
        
            _explosionAudio.Play();
            
            // TODO: Obj pool pls
            Destroy(gameObject);
        }
    }
}
