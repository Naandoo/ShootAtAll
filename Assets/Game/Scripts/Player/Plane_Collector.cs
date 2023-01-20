using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Collector : MonoBehaviour
{
    private List<GameObject> Items = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Item")
        {
            Items.Add(collider.gameObject);
            Destroy(collider.gameObject);
            GameController.Instance.ShowItensUI();
        }
    }

}
