using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    #region private variables
    private float localTime;
    #endregion

    #region Serialized Fields
    [SerializeField] private float TimeToSpawn;
    [SerializeField] private GameObject[] SpawnPositions;
    #endregion

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        localTime += Time.deltaTime;

        if(localTime > TimeToSpawn)
        {
            GameObject enemy = EnemiesObjectPool.SharedInstance.GetPooledObject();

            if(enemy != null)
            {
                int randomPosition = Random.Range(0, SpawnPositions.Length);
                enemy.transform.position = SpawnPositions[randomPosition].transform.position;
                enemy.transform.rotation = SpawnPositions[randomPosition].transform.rotation;
                enemy.SetActive(true);
            }

            localTime = 0f;
        }
    }
}
