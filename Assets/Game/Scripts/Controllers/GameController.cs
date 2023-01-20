using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    #region Public Variables
    public static GameController Instance {get; private set;}
    public GameObject Player;
    private int defeatedEnemies;
    #endregion
    
    #region Serialized Variables
    [SerializeField] private GameObject Boss;
    [SerializeField] private int AmountOfEnemies;
    [SerializeField] private GameObject[] ItensUI;
    #endregion
    
    #region Private Variables
    SpawnEnemies spawnEnemies;
    private int itemIndex = 0;
    #endregion

    #region Getters/Setters
    public int DefeatedEnemies { get => defeatedEnemies; set => defeatedEnemies = value; }
    public int ItemIndex { get => itemIndex; set => itemIndex = value; }
    #endregion

    private void Awake()
    {
        if(Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
        spawnEnemies = GetComponent<SpawnEnemies>();
        ShowItensUI();
    }

    public void CountOfEnemies()
    {
        DefeatedEnemies++;
        if(DefeatedEnemies == AmountOfEnemies)
        {
            GameObject boss = Instantiate(Boss, Boss.transform.position, Quaternion.identity);
            DefeatedEnemies = 0;
            spawnEnemies.enabled = false;
        }
    }

    public void SpawnEnemiesAgain()
    {
        spawnEnemies.enabled = true;
    }

    public void ShowItensUI()
    {

        if(itemIndex < 3)
        {
            ItensUI[itemIndex].SetActive(true);
            if(itemIndex >= 1) ItensUI[itemIndex - 1].SetActive(false);
            itemIndex += 1;
        } 
        else Invoke("ReloadScene", 1f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Shooter");
    }
}
