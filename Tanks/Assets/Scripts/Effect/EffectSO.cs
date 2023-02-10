using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class EffectSO : ScriptableObject
{
    #region Fields
    public float timeToTurnOff;
    #endregion

    public virtual EffectState AddEffectState(GameObject go)
    {
        return null;
    }
}
