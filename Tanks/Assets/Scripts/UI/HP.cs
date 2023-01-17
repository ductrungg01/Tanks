using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private Text textValue;
    
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = DataHolderUtil.StrengthRightnow / ConfigurationUtil.StartingHealth;
        textValue.text = (int)DataHolderUtil.StrengthRightnow + "/" + ConfigurationUtil.StartingHealth;
    }
}
