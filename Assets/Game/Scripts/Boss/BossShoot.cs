using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] private GameObject aim;
    [SerializeField] private float timeBetweenShoots;
    #endregion
    #region Private Variables
    private float localTime;
    private Boss boss;
    private BossHealth bossHealth;
    #endregion
    #region Getters/Setters
    public GameObject Aim { get => aim; set => aim = value; }
    #endregion
    private void OnEnable()
    {
        boss = GetComponent<Boss>();
        bossHealth = GetComponent<BossHealth>();
    }
    void Update()
    {
        ShootBullet();
    }

    public void ShootBullet()
    {
        if(Aim != null && boss.StartToAttack && !bossHealth.IsDead)
        {
            localTime += Time.deltaTime;
            if(localTime > timeBetweenShoots)
            {
                GameObject bullet = ObjectPoolShoots.SharedInstance.GetPooledObjects();
                if(bullet != null)
                {
                    bullet.transform.position = Aim.transform.position;
                    bullet.transform.rotation = Aim.transform.rotation;
                    bullet.SetActive(true);
                }

                localTime = 0;
                
            }
        }
    }
}
