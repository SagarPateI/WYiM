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
        Go = true;
        tf = innerRet.GetComponent<Transform>();
        // pivot = tf.positon;
        tf.position = outerRet.transform.position;
    }/*
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("OuterCrosshairOrigin"))
        {
            rb.AddForce(Vector3.up * force * (invert ? 1:-1),ForceMode2D.Impulse);
            invert = !invert;
        }
    }
    */

    // Update is called once per frame

    void Update()
    {
        //pivot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       pivot = outerRet.transform.position;
    }
    void FixedUpdate() {

        pivot = outerRet.transform.position;

        pivotOffset = (Vector2.one * .3f);
       // pivotOffset1 = OuterRect.transform * .3f;
    
    

        phase += 1 * Time.deltaTime * 1.75f;
        phase2 += 1 * Time.deltaTime*3.5f;
       // tf.Rotate((rotateAngle), Space.Self);
        if(phase >= circle )
        {
           
            
           //infinity = !infinity;



         //  fig8 = !fig8;

            invert = !invert;

           
          phase -= circle;
        }
        if(phase2 >= (2 * circle))
        {
            fig8 = !fig8;
            infinity = !infinity;
           // Go = !Go;
            //invert = !invert;
            phase2 -= (2*circle);
        }
       
        if (phase < 0) { phase += circle;
            //loopCount++;
        }
        if (Go == true)
        {
            float scale = 2f / (3f - Mathf.Cos(2f * phase));
            
            pivot.y += scale * Mathf.Cos(phase);
            pivot.x += scale * Mathf.Sin(2f * phase) / 2f;
          
           
            tf.position = pivot;
        }
     /*   if(Go == false)
        {
            float scale = 2f / (3f - Mathf.Cos(2f * phase));
            pivot.y += scale * Mathf.Cos(phase) * 1.75f;
            pivot.x += scale * Mathf.Sin(2f * phase) / -1.5f;
            
            tf.position = pivot;

        }
        
        if (infinity&&!fig8)
        {
            pivot.y += ((Mathf.Sin(phase))) *1f;
            pivot.x += ((Mathf.Cos(phase)) * (invert ? -1 : 1)) * 1f;
            tf.position = pivot  + (!invert ? -(pivotOffset) : (pivotOffset));
            //invert = !invert;
        }
        
       if (fig8&&!infinity)
        {
            pivot.x += ((Mathf.Sin(phase)) *(invert? -1:-1))* 1f;
            pivot.y += ((Mathf.Cos(phase)) * (invert ? 1 : -1)) * 1f;
            tf.position = pivot + (!invert ? -( pivotOffset) : (pivotOffset));
            //invert = !invert;
        }
       */
       
       //tf.position = pos;
    }

}
