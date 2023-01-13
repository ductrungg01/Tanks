using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;

    [Header("Shell")] [SerializeField] private List<GameObject> pooledShells;
    [SerializeField] private GameObject shellToPool;
    [SerializeField] private int amountOfShellToPoll;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        pooledShells = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountOfShellToPoll; i++)
        {
            tmp = Instantiate(shellToPool);
            tmp.SetActive(false);
            pooledShells.Add(tmp);
        }
    }

    public GameObject GetShell(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < amountOfShellToPoll; i++)
        {
            if (!pooledShells[i].activeInHierarchy)
            {
                GameObject go = pooledShells[i];
                go.transform.position = position;
                go.transform.rotation = rotation;
                go.SetActive(true);
                return go;
            }
        }

        return null;
    }

    public async UniTask DestroyGameObject(GameObject go, float delayTimeInSecond = 0f)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(delayTimeInSecond));
        
        go.SetActive(false);
    }

}
