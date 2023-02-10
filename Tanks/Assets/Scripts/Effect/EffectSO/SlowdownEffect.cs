    using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

    [CreateAssetMenu(fileName = "New Slowdown Effect", menuName = "Effects/Slowdown Effect")]
public class SlowdownEffect : EffectSO
{
    public float _slowdownSpeed;

    public override EffectState AddEffectState(GameObject go)
    {
        SlowdownEffectState slowdownEffectState = go.AddComponent<SlowdownEffectState>();
        slowdownEffectState.timeToTurnOff = timeToTurnOff;
        slowdownEffectState.slowdownSpeed = _slowdownSpeed;

        return slowdownEffectState;
    }
}
