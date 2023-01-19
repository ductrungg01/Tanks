using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShooting : MonoBehaviour
{
    public float _MinLaunchForce = 15f; 
    public float _MaxLaunchForce = 30f; 
    
    public Transform _FireTransform; 
    private float _CurrentLaunchForce;

    public AudioSource _ShootingAudio;
    public AudioClip _FireClip;

    private float _Cooldown = 3f;
    private float _CooldownRemain = 0;
    
    private void Update()
    {
        if (_CooldownRemain > 0)
        {
            _CooldownRemain -= Time.deltaTime;
        } else
        {
            _CooldownRemain = _Cooldown;
            Fire();
        }
    }

    private void Fire()
    {
        // Instantiate and launch the shell.

        GameObject shell = PoolManager.Instance.shellPooler.OnTakeFromPool(_FireTransform.position, _FireTransform.rotation);
        
        if (shell)
        {
            Rigidbody shellInstance = shell.GetComponent<Rigidbody>();

            _CurrentLaunchForce = Random.Range(_MinLaunchForce, _MaxLaunchForce);
            
            shellInstance.velocity = _CurrentLaunchForce * _FireTransform.forward;

            _ShootingAudio.clip = _FireClip;
            _ShootingAudio.Play();
        }
        else
        {
            Debug.Log("Cannot fire!");
        }
        
    }
}
