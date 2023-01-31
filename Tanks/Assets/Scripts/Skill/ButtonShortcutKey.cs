using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShortcutKey : MonoBehaviour
{
    [SerializeField] private KeyCode shortcutKey;

    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(shortcutKey))
        {
            btn.onClick.Invoke();
        }
    }
}
