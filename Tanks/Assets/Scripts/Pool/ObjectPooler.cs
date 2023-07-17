using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectPooler : MonoBehaviour
{
    #region Fields
    private GameObject _CollapsePollerGO;
    private List<GameObject> _PooledObject = new List<GameObject>();
    [SerializeField] private GameObject _ObjectToPool;
    [SerializeField] private int _AmountToPool;
    #endregion
    
    void Start()
    {
        _CollapsePollerGO = this.gameObject;
        Save();
    }

    public void Save()
    {
        if (_ObjectToPool == null) return;

        GameObject go;
        for (int i = 0; i < _AmountToPool; i++)
        {
            go = Instantiate(_ObjectToPool);
            go.transform.parent = _CollapsePollerGO.transform; 
            go.SetActive(false);
            _PooledObject.Add(go);
        }
    }

    public GameObject OnTakeFromPool()
    {
        for (int i = 0; i < _PooledObject.Count; i++)
        {
            if (!_PooledObject[i].activeInHierarchy)
            {
                GameObject go = _PooledObject[i];
                go.SetActive(true);
                return go;
            }
        }

        return null;
    }

    public GameObject OnTakeFromPool(Vector3 position, Quaternion rotation)
    {
        GameObject go = OnTakeFromPool();
        if (go) 
        {
            go.transform.position = position;
            go.transform.rotation = rotation;

            return go;
        }

        return null;
    }

    public async UniTask OnReturnToPool(GameObject go, float delayTimeInSecond = 0)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(delayTimeInSecond));

        if (go.gameObject != null)
        {
            go.transform.parent = _CollapsePollerGO.transform;
            go.SetActive(false);
        }
    }
}
