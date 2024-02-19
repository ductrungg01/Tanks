using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShooting : MonoBehaviour
{
    #region Fields
    public float _MinLaunchForce = 15f; 
    public float _MaxLaunchForce = 30f; 
    
    public Transform _FireTransform; 
    private float _CurrentLaunchForce;

    public AudioSource _ShootingAudio;
    public AudioClip _FireClip;

    private float _CooldownMin = 2f;
    private float _CooldownMax = 5f;
    private float _CooldownRemain;

    public bool isStopShooting = false;
    #endregion
    
    private void Start()
    {
        _CooldownRemain = Random.Range(_CooldownMin, _CooldownMax);
    }

    private void Update()
    {
        if (isStopShooting == true) return;
        
        if (_CooldownRemain > 0)
        {
            _CooldownRemain -= Time.deltaTime;
        } else
        {
            _CooldownRemain = Random.Range(_CooldownMin, _CooldownMax);
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
