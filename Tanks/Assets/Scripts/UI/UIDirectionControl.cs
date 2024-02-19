using UnityEngine;
using UnityEngine.Serialization;

public class UIDirectionControl : MonoBehaviour
{
    public bool _UseRelativeRotation = true;

    private Quaternion _RelativeRotation;     


    private void Start()
    {
        _RelativeRotation = transform.parent.localRotation;
    }


    private void Update()
    {
        if (_UseRelativeRotation)
            transform.rotation = _RelativeRotation;
    }
}
