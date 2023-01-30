using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] private int _manaCost;
    [SerializeField] private int _SkillID;
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
        switch (_SkillID)
        {
            case 1:
            {
                Skill1();
                break;
            }
            case 2:
            {
                Skill2();
                break;
            }
            case 3:
            {
                Skill3();
                break;
            }
        }
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

    #endregion
}
