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

public class FirePie : MonoBehaviour
{

    public Transform FirePoint;
    public Vector3 pieAccuracy = new Vector3(0f,0f,0f);
    public float pieForce = 15f;
    public GameObject Pie;
    public GameObject outerReticle;
    public GameObject innerReticle;
    private Vector3 AccuracyScaler = new Vector3(-.05f,-.05f,0f);
    private Vector3 ZeroVect = new Vector3(0, 0, 0);
    private Vector3 MaxVect = new Vector3(7, 7, 0);

    public float shootTimer = 3f;
    public float reloadTimer = 1.5f;
    private bool isReloading = false;

    public AudioSource audiothrow;
    public AudioClip pieThrow;

    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {

        if (Input.GetButton("Fire1") && isReloading == false)
        {
            outerReticle.transform.localScale += AccuracyScaler;
            //shootTimer -= Time.deltaTime;
            AccuracySlider();
             
        }

        if (Input.GetButtonUp("Fire1") && isReloading == false)
        {
            if (outerReticle.transform.localScale.x <= innerReticle.transform.localScale.x)
            {
                pieAccuracy.x = 0;
                pieAccuracy.y = 0;
            } 
            else
            {
               // pieAccuracy= outerReticle.transform.localScale - innerReticle.transform.localScale; 
            }
            isReloading = true;
            shoot();
            audiothrow.PlayOneShot(pieThrow);
            
            StartCoroutine(reload());
        }



    }
    IEnumerator reload()
    {
        isReloading = true;
        UnityEngine.Debug.Log("Reloading...");
        
        yield return new WaitForSeconds(reloadTimer);
        outerReticle.transform.localScale = MaxVect;
        isReloading = false;
        UnityEngine.Debug.Log("\nReloaded");

       
    }



    void AccuracySlider()
    {
        if (outerReticle.transform.localScale.x >= MaxVect.x)
        {
            AccuracyScaler *= -1;
            // outerReticle.transform.localScale += AccuracyScaler;
        }
        if (outerReticle.transform.localScale.x <= ZeroVect.x)
        {
            AccuracyScaler *= -1;
            //outerReticle.transform.localScale += AccuracyScaler;
        }
        /*
        if (shootTimer <= 0)
        {
            reload();
            


        }*/
    }

    void shoot()
    {

        GameObject piePrefab = Instantiate(Pie, FirePoint.position, FirePoint.rotation);

        Rigidbody2D rb = piePrefab.GetComponent<Rigidbody2D>();
        pieAccuracy.x = Mathf.Abs(pieAccuracy.x);
        pieAccuracy.y = Mathf.Abs(pieAccuracy.y);
       
        rb.AddForce(FirePoint.up * pieForce, ForceMode2D.Impulse);
        UnityEngine.Debug.Log("Shooting");

        //pieForce = 0;

    }
}