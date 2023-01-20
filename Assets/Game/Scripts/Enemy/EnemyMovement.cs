using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float TimeToFollowPlayer;
    private GameObject Player;
    private Rigidbody2D rig;
    private float localTime;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        Player = GameController.Instance.Player;
    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if(!Player.GetComponent<Plane_Health>().IsDead)
        {
            localTime += Time.deltaTime;

            if(localTime < TimeToFollowPlayer) rig.position += Vector2.down * speed  * Time.deltaTime;
            else
            {
                Vector2 direction = Player.transform.position - transform.position;
                transform.rotation = Quaternion.FromToRotation(Vector3.down, direction);

                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * 2 * Time.deltaTime); 
                
            }
        }
        else
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.down, Vector3.up);
            transform.position += -transform.up * speed * Time.deltaTime;
        }
        
    } 
}
