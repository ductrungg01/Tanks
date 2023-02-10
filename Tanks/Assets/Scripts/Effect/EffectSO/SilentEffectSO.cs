using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Silent Effect", menuName = "Effects/Silent Effect")]
public class SilentEffectSO : EffectSO
{
    public override EffectState AddEffectState(GameObject go)
    {
        SilentEffectState silentEffectState = go.AddComponent<SilentEffectState>();
        silentEffectState.timeToTurnOff = timeToTurnOff;
        
        return silentEffectState;
    }
}
