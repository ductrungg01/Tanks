using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingButtonEffect : MonoBehaviour
{
    public void OnSelected()
    {
        foreach (Transform t in transform.GetComponentsInChildren<Transform>())
        {
            t.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
    }
    
    public void OnNotSelected()
    {
        foreach (Transform t in transform.GetComponentsInChildren<Transform>())
        {
            t.localScale = Vector3.one;
        }
    }
    
}
