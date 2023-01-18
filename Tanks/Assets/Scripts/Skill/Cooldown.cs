using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private int _cooldownTime;
    [SerializeField] private Image _cooldownEffect;
    private float _cooldownRemain = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        _cooldownEffect.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _cooldownEffect.fillAmount = _cooldownRemain / _cooldownTime;

        if (_cooldownRemain <= 0)
        {
            _cooldownRemain = 0;
            return;
        }

        _cooldownRemain -= Time.deltaTime;
    }

    public void StartCooldown()
    {
        _cooldownRemain = _cooldownTime;
    }
}
