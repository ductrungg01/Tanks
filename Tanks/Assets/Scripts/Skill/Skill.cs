using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] private int _ManaCost;
    [SerializeField] private int _SkillID;
    private Cooldown _CoolDownEffect;
    private PlayerStats _PlayerStats;
    
    void Start()
    {
        _CoolDownEffect = GetComponent<Cooldown>();
    }

    public void OnClick()
    {
        if (ManaManager.Instance.IsEnoughMana(_ManaCost) && _CoolDownEffect._CanBeUse)
        {
            ManaManager.Instance.OnTakeMana(_ManaCost);
            _CoolDownEffect.StartCooldown();
            
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
        _PlayerStats = GameManager.Instance._Player.GetComponent<PlayerStats>();
        _PlayerStats.Defend += 50;
    }
    void Skill2()
    {
        _PlayerStats = GameManager.Instance._Player.GetComponent<PlayerStats>();
        _PlayerStats.HP += 35;
    }
    void Skill3()
    {
        // TODO: add effect for all enemy instead of add oll enemy for effect
        // StopEffect stopEffectForEnemy = new StopEffect(EnemyManager.Instance.EnemyInstanceList, 10);
        // stopEffectForEnemy.TurnOn();
    }

    #endregion
}
