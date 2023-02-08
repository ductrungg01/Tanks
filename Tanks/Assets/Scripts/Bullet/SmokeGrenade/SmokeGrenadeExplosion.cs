using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SmokeGrenadeExplosion : MonoBehaviour
{
    public ParticleSystem smokeEffect;

    public async UniTask TurnOn()
    {
        smokeEffect.Play();
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        smokeEffect.Play();
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        smokeEffect.Play();
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        smokeEffect.Play();
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
    }
}
