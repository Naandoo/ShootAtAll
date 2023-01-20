using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesObjectPool : MonoBehaviour
{
   #region Public Variables
    public static EnemiesObjectPool SharedInstance;
    private List<GameObject> pooledObjects;
    [SerializeField] private GameObject[] objectToPool;
    [SerializeField] private int amountToPool;
    #endregion
    private void Awake() {
        SharedInstance = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            int EnemyToInstantiate = Random.Range(0, objectToPool.Length);
            tmp = Instantiate(objectToPool[EnemyToInstantiate]);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    public GameObject GetPooledObject()
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
