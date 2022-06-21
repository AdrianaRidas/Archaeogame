using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Sprite PlayerRight;
    public Sprite PlayerLeft;
    public Sprite PlayerStanding;

    public float speed = 10f;
    
    Vector2 lastClickedPosistion;
    
    bool moving;
    public float SCALERATIO; //Groß geschrieben, wel magic number
    float scaleDifference;

    Vector3 scaleChange;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //0 ist die linke Maustaste
        {
            lastClickedPosistion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            scaleDifference = Math.Abs((lastClickedPosistion.y - transform.position.y) * SCALERATIO); //gibt immer einen positiven Wert zurück
            Debug.Log("Scale Difference = " + scaleDifference);
            Debug.Log(new Vector3(scaleDifference, scaleDifference, scaleDifference));
            moving = true;
            if (lastClickedPosistion.y > transform.position.y)
            {
                this.gameObject.transform.localScale -= new Vector3(scaleDifference, scaleDifference, scaleDifference);
                Debug.Log("Geht nach HINTEN");
            }
            else if (lastClickedPosistion.y < transform.position.y)
            {
                this.gameObject.transform.localScale += new Vector3(scaleDifference, scaleDifference, scaleDifference);
                Debug.Log("Geht nach VORNE");
            }
        }

        if (moving && (Vector2)transform.position != lastClickedPosistion)
        {
            float go = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPosistion, go);
            if (lastClickedPosistion.x > transform.position.x)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerRight;
                Debug.Log("Geht nach rechts");
            }
            else if (lastClickedPosistion.x < transform.position.x)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerLeft;
                Debug.Log("Geht nach links");
            } else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerStanding;
                Debug.Log("STEHT");
            }

            
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerStanding;
            moving = false;
        }
    }
}
