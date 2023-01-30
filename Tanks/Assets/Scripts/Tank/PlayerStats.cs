using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Fields
    // Stats
    private float _PlayerSpeed;
    private float _TankMass;
    private float _TankOilRemain;
    private float _TankOilConsumption = 0.15f;
    
    #endregion

    private void Start()
    {
        _PlayerSpeed = ConfigurationUtil.PlayerTankSpeed;
        _TankMass = ConfigurationUtil.TankMass;
        _TankOilRemain = ConfigurationUtil.TankOil;

        SaveStatsForManager();
    }

    private void FixedUpdate()
    {
        TankOilRemain -= _TankOilConsumption / 50;

        PlayerSpeed = ((TankMass - TankOilRemain * 10) / TankMass) * ConfigurationUtil.PlayerTankSpeed;

        SaveStatsForManager();
    }

    void SaveStatsForManager()
    {
        PlayerStatsManager.Instance.PlayerSpeed = _PlayerSpeed;
        PlayerStatsManager.Instance.TankMass = _TankMass;
        PlayerStatsManager.Instance.TankOilRemain = _TankOilRemain;
        PlayerStatsManager.Instance.TankOilConsumption = _TankOilConsumption;
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
