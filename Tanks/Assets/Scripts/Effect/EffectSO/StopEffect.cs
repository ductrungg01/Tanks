using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New Stop Effect", menuName = "Effects/Stop Effect")]
public class StopEffect : EffectSO
{
    public override EffectState AddEffectState(GameObject go)
    {
        StopEffectState stopEffectState = go.AddComponent<StopEffectState>();
        stopEffectState.timeToTurnOff = timeToTurnOff;
        
        return stopEffectState;
    }
}
