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

    public void OnClick()
    {
        if (ManaManager.Instance.IsEnoughMana(_manaCost))
        {
            ManaManager.Instance.OnTakeMana(_manaCost);
            _coolDownEffect.StartCooldown();
            
            DoSkill();
        }
    }

    void DoSkill()
    {
        // TODO: Implement the skill per skill
        // Implement it in the SkillList below
    }

    #region SkillList

    void Skill1()
    {
        
    }
    void Skill2()
    {
        
    }
    void Skill3()
    {
        
    }
    void Skill4()
    {
        
    }
    void Skill5()
    {
        
    }
    void Skill6()
    {
        
    }
    void Skill7()
    {
        
    }
    void Skill8()
    {
        
    }

    #endregion
}
