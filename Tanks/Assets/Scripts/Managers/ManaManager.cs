using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public static ManaManager Instance;
    
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _valueText;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _slider.maxValue = ConfigurationUtil.MaxMana;
        DataHolderUtil.ManaRightnow = ConfigurationUtil.StartingMana;
        _slider.value = DataHolderUtil.ManaRightnow;

        _valueText.text = ((int)_slider.value).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        DataHolderUtil.ManaRightnow += ConfigurationUtil.ManaRecoverSpeed * Time.deltaTime;
        _slider.value = DataHolderUtil.ManaRightnow;
        _valueText.text = ((int)_slider.value).ToString();
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
