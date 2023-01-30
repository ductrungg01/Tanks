using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class TankInformation : MonoBehaviour
{
    #region Fields

    [Header("General Information")] public bool _IsPlayer = false;
    
    // Stats
    private float _PlayerSpeed;
    private float _TankMass;
    private float _TankOilRemain;
    private float _TankOilConsumption = 0.05f;

    #endregion

    private void Start()
    {
        _PlayerSpeed = ConfigurationUtil.PlayerTankSpeed;
        _TankMass = ConfigurationUtil.TankMass;
        _TankOilRemain = ConfigurationUtil.TankOil;
    }

    private void FixedUpdate()
    {
        TankOilRemain -= _TankOilConsumption;

        PlayerSpeed = ((TankMass - TankOilRemain) / TankMass) * ConfigurationUtil.PlayerTankSpeed;
    }

    #region Propertises

    public float PlayerSpeed
    {
        get { return _PlayerSpeed; }
        set { _PlayerSpeed = value; }
    }
    public float TankMass
    {
        get { return _TankMass; }
        set { _TankMass = value; }
    }
    public float TankOilRemain
    {
        get { return _TankOilRemain; }
        set { _TankOilRemain = value; }
    }
    
    #endregion
}
