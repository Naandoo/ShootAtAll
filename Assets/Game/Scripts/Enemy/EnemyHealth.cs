using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float TimeToDisable;
    private Animator anim;
    private int healthAux;
    private EnemyAnimation enemyanim;
    private AudioSource audioSource;
    private void Start()
    {
        enemyanim = GetComponent<EnemyAnimation>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        healthAux = health;
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Bullet")
        {
            healthAux--;
            if(healthAux > 1) enemyanim.Hit();
            else
            {
                gameObject.GetComponent<Collider2D>().enabled = false;

                enemyanim.Die();
                GameController.Instance.CountOfEnemies();
                audioSource.Play();
            } 
        }
    }

    private void Disable()
    {
        gameObject.SetActive(false);

        enemyanim.idle();
    }
}
