using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Security;
using System.Threading;
using UnityEngine;
using System.Collections.Specialized;
using System;
using System.ComponentModel.Design;

public class FirePie : MonoBehaviour
{

    public Transform FirePoint;

    public float pieForce = 15f;
    public GameObject Pie;
    private GameObject outerReticle;
    private GameObject innerReticle;
    private bool hit = false;

    public float reloadTimer = 1.5f;
    private bool isReloading = false;
    public int pieNum; //Setting up for pie counter and updating
    public PauseMenu Pies;

    public AudioSource audiothrow;
    public AudioClip pieThrow;

    public Collider2D pieHitbox;

    // Animation triggers
    public Animator animator;


    void Start()
    {
        Cursor.visible = true;
        outerReticle = GameObject.Find("outerCrosshair");
        innerReticle = GameObject.Find("innerCrosshair");
    }

    void Update()
    {
        pieNum = Pies.getPieNum();
        if (Input.GetButtonDown("Fire1") && isReloading == false && pieNum > 0)
        {
            Pies.usePie();
            animator.SetBool("Throwing", true);
            StartCoroutine(pieDelay());
            audiothrow.PlayOneShot(pieThrow);
            StartCoroutine(reload());
        }
        if (!Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Throwing", false);
        }


    }
    IEnumerator reload()
    {
        isReloading = true;
        UnityEngine.Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTimer);

        isReloading = false;
        UnityEngine.Debug.Log("\nReloaded");


    }
    // Wait for a little bit of time before throwing the pie to sync up the animation to the throw
    IEnumerator pieDelay()
    {
        // disable movement while the player is throwing a pie
        //GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSecondsRealtime(0.2F);
        shoot();
        //GetComponent<PlayerMovement>().enabled = true;
    }


    IEnumerator hitMiss()
    {
        if (hit == true)
        {
            pieHitbox.enabled = true;
        }
        else
        {
            //pieHitbox.enabled = false; 
            if (pieHitbox != null)
            {
                pieHitbox.enabled = false;
            }
        }

        yield return new WaitForSeconds(reloadTimer);
        //pieHitbox.enabled = false; 
        if (pieHitbox != null)
        {
            pieHitbox.enabled = false;
        }

    }


    void shoot()
    {

        GameObject piePrefab = Instantiate(Pie, FirePoint.position, FirePoint.rotation);

        Rigidbody2D rb = piePrefab.GetComponent<Rigidbody2D>();
        pieHitbox = piePrefab.GetComponent<Collider2D>();
        pieHitbox.enabled = false;


        if (Mathf.Abs(innerReticle.transform.position.x) - Mathf.Abs(outerReticle.transform.position.x) <= outerReticle.transform.localScale.x && Mathf.Abs(innerReticle.transform.position.y) - Mathf.Abs(outerReticle.transform.position.y) <= outerReticle.transform.localScale.y)
        {
            hit = true;
            UnityEngine.Debug.Log("hit!!!");
        }
        else
        {
            hit = false;
            UnityEngine.Debug.Log("Miss!!!");
        }
        StartCoroutine(hitMiss());


        rb.AddForce(FirePoint.up * pieForce, ForceMode2D.Impulse);
        UnityEngine.Debug.Log("Shooting");
    }
}