using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Fields
    // Stats
    private int _HP;
    private int _Defend;
    private float _PlayerSpeed;
    private float _TankMass;
    private float _TankOilRemain;
    private float _TankOilConsumption = 0.15f;

    private TankInformation _TankInformation;
    #endregion

    private void Start()
    {
        _PlayerSpeed = ConfigurationUtil.PlayerTankSpeed;
        _TankMass = ConfigurationUtil.TankMass;
        _TankOilRemain = ConfigurationUtil.TankOil;
        _Defend = ConfigurationUtil.Defend;
        _HP = (int)ConfigurationUtil.StartingHealth;
        
        _TankInformation = GetComponent<TankInformation>();
        
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
        PlayerStatsManager.Instance.HP = _HP;
        PlayerStatsManager.Instance.Defend = _Defend;
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
            _HP = value;

            _HP = Mathf.Max(0, _HP);
            //_HP = Mathf.Min((int)ConfigurationUtil.StartingHealth, _HP);
            
            if (_TankInformation._IsPlayer)
            {
                TankHealth health = GetComponent<TankHealth>();
                health.CurrentHealth = _HP;
            }
        }
    }
    
    #endregion
}
