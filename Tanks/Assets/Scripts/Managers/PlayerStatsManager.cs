using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager Instance;
    
    // Stats
    [HideInInspector] public float HP;
    [HideInInspector] public float PlayerSpeed;
    [HideInInspector] public float TankMass;
    [HideInInspector] public float TankOilRemain;
    [HideInInspector] public float TankOilConsumption = 0.05f;
    
    // UI
    [SerializeField] private Text _SpeedText;
    [SerializeField] private Slider _OilSlider;
    [SerializeField] private Text _OilText;
    [SerializeField] private Text _DefendText;
    [SerializeField] private Text _OilConsumptionText;
    [SerializeField] private Text _Mass;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        _SpeedText.text = String.Format("{0:0.0000}", PlayerSpeed);
        
        _OilSlider.value = TankOilRemain / ConfigurationUtil.TankOil;
        _OilText.text = String.Format("{0:0.00}", TankOilRemain) + "/" + ConfigurationUtil.TankOil;
        // TODO: Replacing it
        _DefendText.text = "132";

        _OilConsumptionText.text = (int)TankOilConsumption + "/s";
        _Mass.text = String.Format("{0:0.0}", TankMass + TankOilRemain) + "kg";
    }
}
