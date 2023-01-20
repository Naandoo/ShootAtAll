using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Health : MonoBehaviour
{
    private bool isDead = false;
    private Animator anim;
    private Shoot shoot;
    public bool IsDead { get => isDead; set => isDead = value; }
    private AudioSource audioSource;
    private void Start()
    {
        anim = GetComponent<Animator>();
        shoot = GetComponent<Shoot>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Damage")
        {
            if(!IsDead) audioSource.Play();
            anim.SetTrigger("Die");
            IsDead = true;
            shoot.Aim = null;
           GameController.Instance.Invoke("ReloadScene", 2f);
        }    
    }


}
