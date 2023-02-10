using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class TankEffectHolder : MonoBehaviour
{
    private List<EffectSO> _effects = new List<EffectSO>();
    public EffectSO silent;
    public EffectSO slowdown;

    private void Start()
    {
        //ePbx.AddEffectState(gameObject);
        silent.AddEffectState(gameObject);
        slowdown.AddEffectState(gameObject);
    }

    public void AddEffect(EffectSO e)
    {
        _effects.Add(e);
    }

    public void RemoveEffect(EffectSO e)
    {
        for (int i = 0; i < _effects.Count; i++)
        {
            if (_effects[i].GetType() == e.GetType())
            {
                _effects.Remove(_effects[i]);
            }
        }
    }

    public void RemoveAllEffect()
    {
        _effects.Clear();
    }
}
