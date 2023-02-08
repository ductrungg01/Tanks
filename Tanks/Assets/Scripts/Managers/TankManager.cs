using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class TankManager
{
    #region Fields
    public Transform _SpawnPoint;
    
    [HideInInspector] public string _ColoredPlayerText;
    [HideInInspector] public GameObject _Instance;          
    [HideInInspector] public int _Wins;
    
    private GameObject _CanvasGameObject;
    
    private Color _EnemyColor = new Color(154f/255f, 0, 124f/255f, 1);
    #endregion
    
    public void Setup()
    {
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
        _CanvasGameObject.SetActive(false);
    }

    public void EnableControl()
    {
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
