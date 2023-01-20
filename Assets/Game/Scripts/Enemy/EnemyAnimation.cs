using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [HideInInspector] public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void idle()
    {
        anim.SetTrigger("idle");
    }

    public void Hit()
    {
        anim.SetTrigger("hit");
    }

    public void Die()
    {
        anim.SetTrigger("die");

    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }


}
