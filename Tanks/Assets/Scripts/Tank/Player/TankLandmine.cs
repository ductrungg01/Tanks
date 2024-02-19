using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TankLandmine : MonoBehaviour
{
    [SerializeField] private GameObject _LandminePrefab;
    [SerializeField] private Transform _LandmineTransform;
    [SerializeField] private KeyCode _ShortcutKey = KeyCode.L;

    private TankInformation _TankInformation;

    private void Start()
    {
        _TankInformation = GetComponent<TankInformation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(_ShortcutKey) && _TankInformation._IsPlayer)
        {
            PutLandmine();
        }        
    }

    public void PutLandmine()
    {
        GameObject landmine = Instantiate(_LandminePrefab);
        landmine.transform.position = _LandmineTransform.position;
    }
}
