using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalAttack : MonoBehaviour
{
    [SerializeField] private KeyCode shortcutKey;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(shortcutKey))
        {
            GetComponent<Button>().onClick.Invoke();
            DoAttack();
        }
    }

    void DoAttack()
    {
        // TODO: implement the attack
    }

}
