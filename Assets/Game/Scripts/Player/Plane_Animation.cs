using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Animation : MonoBehaviour
{
    #region Private Variables
    private Animator anim;
    private Movement movement;
    #endregion
    #region Serialized Fields
    [SerializeField] private float MinDistToAnim;
    #endregion
    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        anim.SetTrigger("Idle");
    }

    void Update()
    {
        PlayAnimations();   
    }

    private void PlayAnimations()
    {
        if(movement.TouchPos.x > transform.position.x + MinDistToAnim|| movement.TouchPos.x < transform.position.x - MinDistToAnim)
        {
            if(movement.TouchPos.x > 0){
                anim.SetTrigger("Right");
            } 
            else if(movement.TouchPos.x < 0){
                anim.SetTrigger("Left");
            } 
        }
        else anim.SetTrigger("Idle");
    }



}
