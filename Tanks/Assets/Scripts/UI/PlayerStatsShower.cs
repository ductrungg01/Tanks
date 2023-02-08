using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsShower : MonoBehaviour
{
    #region Fields
    // PlayerInfo
    private String _Name = "Angry ductrungg";
    [SerializeField] private Text _NameText;
    [SerializeField] private Slider _HpSlider;
    [SerializeField] private Text _HpText;
    [SerializeField] private Slider _OilSlider;
    [SerializeField] private Text _OilText;
    
    // Stats
    [SerializeField] private Text _DefendText;
    [SerializeField] private Text _OilConsumptionText;
    [SerializeField] private Text _Mass;
    [SerializeField] private Text _SpeedText;
    
    // PlayerStats
    private PlayerStats _PlayerStats;
    #endregion

    private void Start()
    {
        
    }

    private void Update()
    {
        _PlayerStats = GameManager.Instance._Player.GetComponent<PlayerStats>();
        
        // Get stats from PlayerStatsManager
        float hpRemain = _PlayerStats.HP;
        float maxHp = ConfigurationUtil.StartingHealth;
        float oilRemain = _PlayerStats.TankOilRemain;
        float maxOil = ConfigurationUtil.TankOil;
        
        float defend = _PlayerStats.Defend;
        float oilConsumption = 0.25f;
        float mass = _PlayerStats.TankMass;
        float speed = _PlayerStats.PlayerSpeed;


        // Show
        _NameText.text = _Name;
        _HpSlider.value = hpRemain / maxHp;
        _HpText.text = hpRemain + "/" + maxHp;
        _OilSlider.value = oilRemain / maxOil;
        _OilText.text = String.Format("{0:0.00}", oilRemain)  + "/" + (int)maxOil;

        _DefendText.text = ((int)defend).ToString();
        _OilConsumptionText.text = String.Format("{0:0.00}", oilConsumption) + "/s";
        _Mass.text = String.Format("{0:0.0}", mass + oilRemain) + "kg";
        _SpeedText.text = String.Format("{0:0.0000}", speed);
    }
}
