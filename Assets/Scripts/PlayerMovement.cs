using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    
    Vector2 lastClickedPosistion;
    
    bool moving;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //0 ist die linke Maustaste
        {
            lastClickedPosistion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }

        if (moving && (Vector2)transform.position != lastClickedPosistion)
        {
            float go = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPosistion, go); 
        } else
        {
            moving = false;
        }
    }
}
