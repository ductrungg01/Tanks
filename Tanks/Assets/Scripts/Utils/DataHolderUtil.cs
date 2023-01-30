using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolderUtil
{
    // Mana
    private static float _ManaRightnow;
    public static float ManaRightnow
    {
        get { return _ManaRightnow; }
        set { _ManaRightnow = Mathf.Min(value, ConfigurationUtil.MaxMana); }
    }
    
}
