using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Private Variables
    Vector2 touchPos;
    Plane_Health playerHealth;
    #endregion
    
    #region Serialized Fields
    [SerializeField] private float speed;

    #endregion

    #region Getters/Setters
    public Vector2 TouchPos { get => touchPos; set => touchPos = value; }
    #endregion

    private void Start()
    {
        playerHealth = GetComponent<Plane_Health>();
    }
    void Update()
    {
        TouchAction();
    }

    private void TouchAction()
    {
        if(!playerHealth.IsDead)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                TouchPos = Camera.main.ScreenToWorldPoint(touch.position);
                switch(touch.phase)
                {
                    case TouchPhase.Moved:
                    transform.position = Vector2.MoveTowards(transform.position, TouchPos, speed * Time.deltaTime);
                    break;

                    case TouchPhase.Stationary:
                    transform.position = Vector2.MoveTowards(transform.position, TouchPos, speed * Time.deltaTime);
                    break;
                    
                    case TouchPhase.Ended:
                    touchPos = Vector2.zero;
                    break;

                    case TouchPhase.Canceled:
                    touchPos = Vector2.zero;
                    break;
                }
            }
        }
    }
}
