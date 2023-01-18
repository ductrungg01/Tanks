using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigurationUtil
{
    // Health
    private static float _startingHealth = 100f;
    
    // Mana
    private static int _maxMana = 10;
    private static int _startingMana = 3;
    private static float _manaRecoverSpeed = 0.4f;
    

    public static float StartingHealth
    {
        get { return _startingHealth; }
    }

    public static int MaxMana
    {
        get { return _maxMana; }
    }
    
    public static int StartingMana
    {
        get { return _startingMana; }
    }

    public static float ManaRecoverSpeed
    {
        get { return _manaRecoverSpeed; }
    }
}
