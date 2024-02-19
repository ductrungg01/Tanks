using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingButtonEffectManager : MonoBehaviour
{
    public List<ShootingButtonEffect> ButtonEffects = new List<ShootingButtonEffect>();

    public void ResetAllButtonEffect()
    {
        foreach (var e in ButtonEffects)
        {
            e.OnNotSelected();
        }
    }
}
