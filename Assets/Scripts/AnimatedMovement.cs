using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedMovement : MonoBehaviour
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
            hit = Physics2D.Raycast(lastClickedPosistion, Vector2.zero);
            moving = true;
            if (lastClickedPosistion.y > transform.position.y && hit.collider.gameObject.tag == "Ground")
            {
                this.gameObject.transform.localScale -= new Vector3(scaleDifference, scaleDifference, scaleDifference);
            }
            else if (lastClickedPosistion.y < transform.position.y && hit.collider.gameObject.tag == "Ground")
            {
                this.gameObject.transform.localScale += new Vector3(scaleDifference, scaleDifference, scaleDifference);
            }
            else
            {
                Debug.Log("Dort kann man nicht hinlaufen");
            }
        } 

        

        if (moving && (Vector2)transform.position != lastClickedPosistion && hit.collider.gameObject.tag == "Ground")
        {
            float go = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPosistion, go);
            if (lastClickedPosistion.x > transform.position.x)
            {
                animator.SetBool("walkright", true);
            }
            else if (lastClickedPosistion.x < transform.position.x)
            {
                animator.SetBool("walkleft", true);
            } else
            {
                animator.SetBool("walkleft", false);
                animator.SetBool("walkright", false);
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
