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
    private Rigidbody2D rb;

   
    public float pieForce = 15f;
    public GameObject Pie;
    public GameObject PieFake;
    private GameObject outerReticle;
    private GameObject innerReticle;
    private Renderer crossRender;
    private bool hit = false;
 
    public float reloadTimer = 1.5f;
    private bool isReloading = false;
    public int pieNum; //Setting up for pie counter and updating
    //public PauseMenu Pies;

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

        crossRender = outerReticle.GetComponent<Renderer>();
        pieNum = PlayerPrefs.GetInt("PieAmmo");


    }
    
    
    void Update()
    {

        if (Mathf.Abs(Vector3.Distance(innerReticle.transform.localPosition, outerReticle.transform.localPosition)) <= .9f)
        {

            hit = true;
        }
        else
        {
            hit = false;
        }
        pieNum = PlayerPrefs.GetInt("PieAmmo");
        if (Input.GetButtonDown("Fire1") && !isReloading && pieNum > 0)
        {
            pieNum--;
            PlayerPrefs.SetInt("PieAmmo", pieNum);
            animator.SetBool("Throwing", true);
            StartCoroutine(pieDelay());
            audiothrow.PlayOneShot(pieThrow);
            StartCoroutine(reload());
        }
        else
        {
            animator.SetBool("Throwing", false);
        }


    }
    // Wait for a little bit of time before throwing the pie to sync up the animation to the throw
    IEnumerator pieDelay()
    {
        // disable movement while the player is throwing a pie
        GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSecondsRealtime(0.2f);
        shoot();
        GetComponent<PlayerMovement>().enabled = true;
    }


    IEnumerator reload()
    {
        isReloading = true;
        UnityEngine.Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTimer);
              
        isReloading = false;
        UnityEngine.Debug.Log("\nReloaded");


    }

    void shoot()
    {
        UnityEngine.Debug.Log(innerReticle.transform.localPosition);
        
        UnityEngine.Debug.Log(Vector3.Distance(innerReticle.transform.localPosition, outerReticle.transform.localPosition));
        StartCoroutine(colorSwitch());

        if (hit)
        {
            
            GameObject piePrefab = Instantiate(Pie, FirePoint.position, FirePoint.rotation);
            rb = piePrefab.GetComponent<Rigidbody2D>();
            UnityEngine.Debug.Log("hit!!!");
        }
        if(!hit) 
        {
            crossRender.material.SetColor("_Color", Color.red);
            GameObject piePrefab = Instantiate(PieFake, FirePoint.position, FirePoint.rotation);

            rb = piePrefab.GetComponent<Rigidbody2D>();
            UnityEngine.Debug.Log("Miss!!!");
        }
        
        rb.AddForce(FirePoint.up * pieForce, ForceMode2D.Impulse);
        UnityEngine.Debug.Log("Shooting");
    }


    IEnumerator colorSwitch()
    {
        if (hit)
        {
            crossRender.material.SetColor("_Color", Color.green);
        }
        if(!hit)
        {
            crossRender.material.SetColor("_Color", Color.red);
        }

        yield return new WaitForSeconds(reloadTimer);

        crossRender.material.SetColor("_Color", Color.white);

    }
}