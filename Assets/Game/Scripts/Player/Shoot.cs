using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] private GameObject aim;
    [SerializeField] private float timeBetweenShoots;
    #endregion
    #region Private Variables
    private float localTime;
    public GameObject Aim { get => aim; set => aim = value; }
    #endregion
    void Update()
    {
        ShootBullet();
    }

    public void ShootBullet()
    {
        if(Aim != null)
        {
            localTime += Time.deltaTime;
            if(localTime > timeBetweenShoots)
            {
                GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
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
