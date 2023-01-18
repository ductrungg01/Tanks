using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] private int _manaCost;
    private Cooldown _coolDownEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        _coolDownEffect = GetComponent<Cooldown>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (ManaManager.Instance.IsEnoughMana(_manaCost))
        {
            ManaManager.Instance.OnTakeMana(_manaCost);
            _coolDownEffect.StartCooldown();
        }
    }
}
