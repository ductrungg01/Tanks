using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolderUtil
{
    // Health
    private static float _strengthRightnow;

    // Mana
    private static float _manaRightnow;
    
    public static float StrengthRightnow
    {
        get { return _strengthRightnow; }
        set { _strengthRightnow = value; }
    }
    
    public static float ManaRightnow
    {
        get { return _manaRightnow; }
        set { _manaRightnow = Mathf.Min(value, ConfigurationUtil.MaxMana); }
    }
}
