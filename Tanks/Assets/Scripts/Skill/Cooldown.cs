using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private int _CooldownTime;
    [SerializeField] private Image _CooldownEffect;
    private float _CooldownRemain = 0;
    [HideInInspector] public bool _CanBeUse;
    
    void Start()
    {
        _CooldownEffect.fillAmount = 0;
        _CanBeUse = true;
    }
    
    void Update()
    {
        _CooldownEffect.fillAmount = _CooldownRemain / _CooldownTime;

        if (_CooldownRemain <= 0)
        {
            _CooldownRemain = 0;
            _CanBeUse = true;
            return;
        }

        _CooldownRemain -= Time.deltaTime;
    }

    public void StartCooldown()
    {
        _CooldownRemain = _CooldownTime;
        _CanBeUse = false;
    }
}
