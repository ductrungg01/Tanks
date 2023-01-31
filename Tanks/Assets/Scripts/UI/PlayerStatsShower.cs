using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsShower : MonoBehaviour
{
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
    
    private void Update()
    {
        // Get stats from PlayerStatsManager
        float hpRemain = PlayerStatsManager.Instance.HP;
        float maxHp = ConfigurationUtil.StartingHealth;
        float oilRemain = PlayerStatsManager.Instance.TankOilRemain;
        float maxOil = ConfigurationUtil.TankOil;
        
        float defend = PlayerStatsManager.Instance.Defend;
        float oilConsumption = PlayerStatsManager.Instance.TankOilConsumption;
        float mass = PlayerStatsManager.Instance.TankMass;
        float speed = PlayerStatsManager.Instance.PlayerSpeed;


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
