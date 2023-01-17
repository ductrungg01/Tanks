using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private GameObject CollapsePollerGO;
    private List<GameObject> pooledObject;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;

    // Start is called before the first frame update
    void Start()
    {
        CollapsePollerGO = this.gameObject;
        Save();
    }

    public void Save()
    {
        GameObject go;
        for (int i = 0; i < amountToPool; i++)
        {
            go = Instantiate(objectToPool);
            go.transform.parent = CollapsePollerGO.transform; 
            go.SetActive(false);
            pooledObject.Add(go);
        }
    }

    public GameObject OnTakeFromPool()
    {
        for (int i = 0; i < pooledObject.Count; i++)
        {
            if (!pooledObject[i].activeInHierarchy)
            {
                GameObject go = pooledObject[i];
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

        go.transform.parent = CollapsePollerGO.transform;
        go.SetActive(false);
    }
}
