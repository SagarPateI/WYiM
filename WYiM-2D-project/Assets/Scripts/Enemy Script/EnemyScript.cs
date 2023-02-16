using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // TODO: Add specific hitbox?
    // play certain sound when hit on the side and do nothing
    // play other sound when hit around the front/face and stun/kill enemy

    //public AudioSource clank;     //If player hits on side
    public AudioSource groan;       //If player hits on front
    public AudioSource pieHit;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public float soundDelay = 0.1f; //plays the groan sound slightly after getting hit by pie

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pie"))
        {
            //Debug.Log("testing sound");
            pieHit.Play();
            groan.PlayDelayed(soundDelay);      //So that it doesn't sound weird that they make a sound at the EXACT same time of being hit, there's a slight delay
            rend.enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 3f);    //Disable the sprite so that the audio still plays
        }
    }
}
