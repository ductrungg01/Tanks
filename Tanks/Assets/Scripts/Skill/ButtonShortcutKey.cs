using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonShortcutKey : MonoBehaviour
{
    [SerializeField] private KeyCode _ShortcutKey;

    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
    }
    
    void Update()
    {
        if (Input.GetKey(_ShortcutKey))
        {
            btn.onClick.Invoke();
        }
    }
}
