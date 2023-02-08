using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Fields
    private int _HP;
    private int _Defend;
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
        _Defend = ConfigurationUtil.Defend;
        _HP = (int)ConfigurationUtil.StartingHealth;
    }

    private void FixedUpdate()
    {
        TankOilRemain -= _TankOilConsumption / 50;

        PlayerSpeed = ((TankMass - TankOilRemain * 10) / TankMass) * ConfigurationUtil.PlayerTankSpeed;
    }

    #region Propertises
    public float PlayerSpeed
    {
        get { return _PlayerSpeed; }
        set
        {
            if (value < 0) value = 0;
            _PlayerSpeed = value;
        }
    }
    public float TankMass
    {
        get { return _TankMass; }
        set
        {
            if (value < 0) value = 0;
            _TankMass = value;
        }
    }
    public float TankOilRemain
    {
        get { return _TankOilRemain; }
        set
        {
            if (value < 0) value = 0;
            _TankOilRemain = value;
        }
    }
    public int Defend
    {
        get { return _Defend; }
        set { _Defend = value; }
    }

    public int HP
    {
        get { return _HP; }
        set
        {
            if (value < 0) value = 0;
            _HP = value;

            _HP = Mathf.Min(_HP, (int)ConfigurationUtil.StartingHealth);
        }
    }
    
    #endregion
}
