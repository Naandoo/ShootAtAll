using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Private Variables
     private Rigidbody2D rig;
    #endregion

    #region Serialized Fields
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;    
    private float lifeTimeAux;
    #endregion

    #region public variables
    public enum Direction{Up, Down}
    public Direction direction;
    #endregion
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        lifeTimeAux += Time.deltaTime;
        if(lifeTimeAux >= lifeTime) DisableBullet();
        Movement();
    }
    private void Movement()
    {
        switch(direction)
        {
            case Direction.Up:
                rig.velocity = transform.up * speed;
                break;
            case Direction.Down:
                rig.velocity = transform.up * speed;
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
        }
    }
    private void DisableBullet()
    {
        lifeTimeAux = 0;
        gameObject.SetActive(false);
    }
}
