using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimations : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Idle()
    {
        anim.SetTrigger("idle");
    }
    public void SimpleLeft()
    {
        anim.SetTrigger("Left");
    }
    public void SimpleRight()
    {
        anim.SetTrigger("Right");
    }
    public void EscapeRight()
    {
        anim.SetTrigger("EscapeR");
    }
    public void EscapeLeft()
    {
        anim.SetTrigger("EscapeL");
    }
    public void Escape()
    {
        anim.SetTrigger("Up");
    }

    public void DisableBoss()
    {
        gameObject.SetActive(false);
    }
}
