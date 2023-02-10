using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Poison Effect", menuName = "Effects/Poison Effect")]
public class PoisonedEffectSO : EffectSO
{
    public float durationTime;
    public float damage;

    public override EffectState AddEffectState(GameObject go)
    {
        PoisonedEffectState poisonEffectState = go.AddComponent<PoisonedEffectState>();
        poisonEffectState.timeToTurnOff = timeToTurnOff;
        poisonEffectState.durationTime = durationTime;
        poisonEffectState.damage = damage;
        
        return poisonEffectState;
    }
}
