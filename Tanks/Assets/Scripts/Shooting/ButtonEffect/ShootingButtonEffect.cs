using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingButtonEffect : MonoBehaviour
{
    public void OnSelected()
    {
        this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(.7f, .7f, 1f);
    }
    
    public void OnNotSelected()
    {
        this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(.6f, .6f, 1f);
    }

}
