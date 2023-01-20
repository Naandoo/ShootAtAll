using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int health;
    private SpriteRenderer sprite;
    private bool isDead;
    private int itemIndex;
    public bool IsDead { get => isDead; set => isDead = value; }
    [SerializeField] GameObject[] items;
    private AudioSource audioSource;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void CheckHealth()
    {
        if(health <= 0)
        {
            audioSource.Play();
            IsDead = true;
            DropItem();
            GameController.Instance.SpawnEnemiesAgain();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            if(health > 0)
            {
                health -= 1;
                CheckHealth();  
                StartCoroutine("ChangeColor");
            } 
        }    
    }
    
    private IEnumerator ChangeColor()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    private void DropItem()
    {
        itemIndex = GameController.Instance.ItemIndex -1 ;
        Instantiate(items[itemIndex], transform.position, Quaternion.identity);
    }
}
