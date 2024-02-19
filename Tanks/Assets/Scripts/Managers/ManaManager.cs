using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    #region Fields
    public static ManaManager Instance;
    
    [SerializeField] private Slider _Slider;
    [SerializeField] private Text _ValueText;
    #endregion

    private void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        _Slider.maxValue = ConfigurationUtil.MaxMana;
        DataHolderUtil.ManaRightnow = ConfigurationUtil.StartingMana;
        _Slider.value = DataHolderUtil.ManaRightnow;

        _ValueText.text = ((int)_Slider.value).ToString();
    }
    
    void Update()
    {
        DataHolderUtil.ManaRightnow += ConfigurationUtil.ManaRecoverSpeed * Time.deltaTime;
        _Slider.value = DataHolderUtil.ManaRightnow;
        _ValueText.text = ((int)_Slider.value).ToString();
    }

    public bool IsEnoughMana(int value)
    {
        return value <= DataHolderUtil.ManaRightnow;
    }
    
    public void OnTakeMana(int value)
    {
        if (!IsEnoughMana(value)) return;
        
        DataHolderUtil.ManaRightnow -= value;
    }
}
