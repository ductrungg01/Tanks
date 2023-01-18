using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankLandmine : MonoBehaviour
{
    [SerializeField] private GameObject _landminePrefab;
    [SerializeField] private Transform _landmineTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // TODO: ObjPool the landmine
            GameObject landmine = Instantiate(_landminePrefab);
            landmine.transform.position = _landmineTransform.position;
        }        
    }
}
