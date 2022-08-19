using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRYOUTMOVE : MonoBehaviour
{
    public Animator animator;

    public float speed = 10f;
    
    Vector2 lastClickedPosistion;
    
    bool moving;
    public float SCALERATIO; //Groß geschrieben, wel magic number
    float scaleDifference;
    RaycastHit2D hit;
    Vector3 scaleChange;
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) //0 ist die linke Maustaste
        {
            lastClickedPosistion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            scaleDifference = Math.Abs((lastClickedPosistion.y - transform.position.y) * SCALERATIO); //gibt immer einen positiven Wert zur�ck
            //Debug.Log("Scale Difference = " + scaleDifference);
            //Debug.Log(new Vector3(scaleDifference, scaleDifference, scaleDifference));
            hit = Physics2D.Raycast(lastClickedPosistion, Vector2.zero);
            //moving = true;
            if (lastClickedPosistion.y > transform.position.y && hit.collider.gameObject.tag == "Ground")
            {
                this.gameObject.transform.localScale -= new Vector3(scaleDifference, scaleDifference, scaleDifference);
                //Debug.Log("Geht nach HINTEN");
                moving = true;
            }
            else if (lastClickedPosistion.y < transform.position.y && hit.collider.gameObject.tag == "Ground")
            {
                this.gameObject.transform.localScale += new Vector3(scaleDifference, scaleDifference, scaleDifference);
                //Debug.Log("Geht nach VORNE");
                moving = true;
            }
            else
            {
                Debug.Log("Dort kann man nicht hinlaufen");
                moving = false;
            }
        }

        

        if (moving && (Vector2)transform.position != lastClickedPosistion && hit.collider.gameObject.tag == "Ground")
        {
            //Debug.Log(hit.collider.gameObject.tag);
            float go = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPosistion, go);
            if (lastClickedPosistion.x > transform.position.x)
            {
                animator.SetBool("walkright", true);
                //Debug.Log("Geht nach rechts");
            }
            else if (lastClickedPosistion.x < transform.position.x)
            {
                animator.SetBool("walkleft", true);
                //Debug.Log("Geht nach links");
            } else
            {
                animator.SetBool("walkleft", false);
                animator.SetBool("walkright", false);
                //Debug.Log("STEHT");
            }

            
        }
        else
        {
            animator.SetBool("walkleft", false);
            animator.SetBool("walkright", false);
            moving = false;
        }
    }
}
