using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingButtonEffect : MonoBehaviour
{
    public void OnSelected()
    {
        //foreach (Transform t in transform.GetComponentsInChildren<Transform>())
        //{
        //    t.localScale = new Vector3(0.7f, 0.7f, 1f);
        //}
        this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(.7f, .7f, 1f);
    }
    
    public void OnNotSelected()
    {
        //foreach (Transform t in transform.GetComponentsInChildren<Transform>())
        //{
        //    t.localScale = new Vector3(0.6f, 0.6f, 1f);
        //}
        this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(.6f, .6f, 1f);

    }

}
