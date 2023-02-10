using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilentEffectState : EffectState
{

    protected override void TurnOn()
    {
        this.gameObject.GetComponent<EnemyShooting>().enabled = false;
    }

    protected override void TurnOff()
    {
        this.gameObject.GetComponent<EnemyShooting>().enabled = true;
        Destroy(gameObject.GetComponent<SilentEffectState>());
    }
}
