using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class TankManager
{
    public Transform _SpawnPoint;
    
    [HideInInspector] public string _ColoredPlayerText;
    [HideInInspector] public GameObject _Instance;          
    [HideInInspector] public int _Wins;

    private TankMovement _Movement;       
    private TankShooting _Shooting;
    private GameObject _CanvasGameObject;
    
    private Color _EnemyColor = new Color(154f/255f, 0, 124f/255f, 1);
    
    public void Setup()
    {
        _Movement = _Instance.GetComponent<TankMovement>();
        _Shooting = _Instance.GetComponent<TankShooting>();
        _CanvasGameObject = _Instance.GetComponentInChildren<Canvas>().gameObject;

        _ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(_EnemyColor) + ">PLAYER "  + "</color>";

        MeshRenderer[] renderers = _Instance.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = _EnemyColor;
        }
    }


    public void DisableControl()
    {
        _Movement.enabled = false;
        _Shooting.enabled = false;

        _CanvasGameObject.SetActive(false);
    }


    public void EnableControl()
    {
        _Movement.enabled = true;
        _Shooting.enabled = true;

        _CanvasGameObject.SetActive(true);
    }


    public void Reset()
    {
        _Instance.transform.position = _SpawnPoint.position;
        _Instance.transform.rotation = _SpawnPoint.rotation;

        _Instance.SetActive(false);
        _Instance.SetActive(true);
    }
}
