using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolShoots : MonoBehaviour
{
    public static ObjectPoolShoots SharedInstance;
    private List<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;

    public List<GameObject> PooledObjects { get => pooledObjects; set => pooledObjects = value; }
    public GameObject ObjectToPool { get => objectToPool; set => objectToPool = value; }

    void Awake()
    {
        SharedInstance = this;
    }

    // Update is called once per frame
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObjects()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
