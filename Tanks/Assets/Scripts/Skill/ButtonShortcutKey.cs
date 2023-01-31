using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShortcutKey : MonoBehaviour
{
    [SerializeField] private KeyCode shortcutKey;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(shortcutKey))
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }
}
