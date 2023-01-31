using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigurationUtil
{
    // Health
    private static float _StartingHealth = 100f;
    
    // Mana
    private static int _MaxMana = 10;
    private static int _StartingMana = 3;
    private static float _ManaRecoverSpeed = 0.4f;
    
    // Speed 
    private static float _PlayerTankSpeed = 12f;
    private static float _EnemyTankSpeed = 3f;
    
    // Mass
    private static float _TankMass = 10000f;
    
    // Petro
    private static float _TankOil = 100f;
    
    // Defend
    private static int _Defend = 132;

    public static float StartingHealth
    {
        get { return _StartingHealth; }
    }

    public static int MaxMana
    {
        get { return _MaxMana; }
    }
    
    public static int StartingMana
    {
        get { return _StartingMana; }
    }

    public static float ManaRecoverSpeed
    {
        get { return _ManaRecoverSpeed; }
    }

    public static float PlayerTankSpeed
    {
        get { return _PlayerTankSpeed; }
    }

    public static float EnemyTankSpeed
    {
        get { return _EnemyTankSpeed; }
    }
    
    public static float TankMass
    {
        get { return _TankMass; }
    }
    
    public static float TankOil
    {
        get { return _TankOil; }
    }
    
    public static int Defend
    {
        get { return _Defend; }
    }
}
