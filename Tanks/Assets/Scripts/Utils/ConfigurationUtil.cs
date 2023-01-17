using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigurationUtil
{
    private static float _startingHealth = 100f;

    public static float StartingHealth
    {
        get { return _startingHealth; }
        set { _startingHealth = value; }
    }
}
