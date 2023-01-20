using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rig;
    private BossHealth bossHealth;
    private float localTime = 0;
    [SerializeField] private float timeToNormalizeMovement;
    [SerializeField] private float timeBetweenCicles;
    private Vector2 firstPosition;
    private bool isExecutingCicle;
    private BossAnimations bossAnimations;
    private int RandomCicle, RandomEscape, randomAux;
    private bool startToAttack;

    public bool StartToAttack { get => startToAttack; set => startToAttack = value; }

    void Start()
    {
        firstPosition = transform.position;
        rig = GetComponent<Rigidbody2D>();
        bossHealth = GetComponent<BossHealth>();
        bossAnimations = GetComponent<BossAnimations>();
    }
    private void OnEnable() {
    StartToAttack = false;    
    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        localTime += Time.deltaTime;
        if(localTime <= timeToNormalizeMovement)
        {
            rig.position += Vector2.down * speed * Time.deltaTime;
        } 
        else
        {
            StartCoroutine("ChooseMovement");
            StartToAttack = true;
        } 
    }

    private int RandomValue(int min, int max)
    {

        int RandomValue = Random.Range(min, max);
    
        if(RandomValue == randomAux)
        {
            RandomValue += 1;
        }    
        else
        {
            return RandomValue;
        }
        
        return RandomValue;
    }
    private IEnumerator ChooseMovement()
    {
        if(!isExecutingCicle)
        {
            isExecutingCicle = true;

            if(!bossHealth.IsDead)
            {
              
                RandomCicle = RandomValue(1,3);
                randomAux = RandomCicle;
                
                if(RandomCicle % 1 == 0)
                { 
                    bossAnimations.SimpleLeft();
                    yield return new WaitForSeconds(timeBetweenCicles);
                    StartCoroutine(ChooseMovement());
                }
                if(RandomCicle % 2 == 0)
                { 
                    bossAnimations.SimpleRight();
                    yield return new WaitForSeconds(timeBetweenCicles);
                    StartCoroutine(ChooseMovement());
                }
                
                isExecutingCicle = false;
            }

            else
            {

                RandomEscape = RandomValue(1,3);
                randomAux = RandomCicle;

                if(RandomEscape % 1 == 0)
                {
                    bossAnimations.EscapeLeft();
                    yield return new WaitForSeconds(timeBetweenCicles);
                    bossAnimations.Escape();
                }

                if(RandomEscape % 2 == 0)
                {
                    bossAnimations.EscapeRight();
                    yield return new WaitForSeconds(timeBetweenCicles);
                    bossAnimations.Escape();
                }
                
            }

        }
    

    }
}
