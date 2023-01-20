using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalParallax : MonoBehaviour
{
    [SerializeField] private float SpeedToScroll;
    private float FirstPosY;
    void Start()
    {   
        FirstPosY = gameObject.GetComponent<RectTransform>().anchoredPosition.y;
    }

    void Update()
    {
        ScrollingScenarioVertical();
    }

    private void ScrollingScenarioVertical()
    {
        float PosY = gameObject.GetComponent<RectTransform>().anchoredPosition.y;
        if(PosY <= -681 )
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(transform.position.x, FirstPosY);
        } 
        else transform.Translate(Vector2.down * SpeedToScroll * Time.deltaTime);  
    }
}
