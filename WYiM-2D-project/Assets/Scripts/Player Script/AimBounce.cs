using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;



public class AimBounce : MonoBehaviour
{

    public Vector3 origin = new Vector3(0,1f,0);
    public Transform tf;

    
   // public Rigidbody2D rb;
    //private Vector3 pivot;
    private Vector3 pivotOffset;
    private Vector3 pivotOffset1;
    private Vector3 pivot;
    private float phase;
    private float phase2;
    private float circle = Mathf.PI *2;
    private bool invert = false;
    public float force = 7;
    private bool sniperBool;

    private GameObject outerRet;
    private GameObject innerRet;

    private bool infinity = true;
    private bool fig8 = false;
    private Vector3 pos;
    private int loopCount = 0;
    private bool Go;
    public float lemx;
    public float lemy;
    public Vector3 movement = new Vector2(1, 1);
    // Start is called before the first frame update
    void Start()

    {
        
        innerRet = GameObject.Find("innerCrosshair");
        outerRet = GameObject.Find("pivotPoint");
        outerRet.SetActive(true);
        Go = true;
        sniperBool = false;
        tf = innerRet.GetComponent<Transform>();
        
        tf.position = outerRet.transform.position;
        
    }

    // Update is called once per frame

    
    
    void FixedUpdate() {
        if (sniperBool == false)
        {

            pivot = outerRet.transform.position;

            pivotOffset = (Vector2.one * .3f);




            phase += 1 * Time.deltaTime * 1.75f;
            phase2 += 1 * Time.deltaTime * 3.5f;

            if (phase >= circle)
            {






                invert = !invert;


                phase -= circle;
            }
            if (phase2 >= (2 * circle))
            {
                fig8 = !fig8;
                infinity = !infinity;

                phase2 -= (2 * circle);
            }

            if (phase < 0)
            {
                phase += circle;
            }
            if (Go == true)
            {
                float scale = 2f / (3f - Mathf.Cos(2f * phase));

                pivot.y += scale * Mathf.Cos(phase);
                pivot.x += scale * Mathf.Sin(2f * phase) / 2f;


                tf.position = pivot;
            }
        }
        else if(sniperBool == true)
        {
            tf.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    
    }
   public void sniperMode()
    {
        sniperBool = true;
        StartCoroutine(SMODE());
        
    }
    IEnumerator SMODE()
    {
        UnityEngine.Debug.Log("sniper");
        
        yield return new WaitForSeconds(10f);
        UnityEngine.Debug.Log("Sniper off");
        sniperBool = false;
    }

}
