using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;

public class rotateOuter : MonoBehaviour
{ 
    public Transform tf;
    private Vector3 offSet;

    private float phase;
    private Vector3 pivot;
    private float circle = 2 * Mathf.PI;
    private float lemx;
    private float temp;
    private float lemy; 

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        offSet = tf.up * .7f;
        pivot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        phase += 3f * Time.deltaTime;
        if(phase >= circle)
        {
            phase -= circle;
        }

        pivot.x += Mathf.Cos(phase);
        pivot.y += Mathf.Sin(phase);
        /*
        float scale = 2f / (3f - Mathf.Cos(2f * phase));
       
        pivot.x+= scale * Mathf.Cos(phase);
        pivot.y += scale * Mathf.Sin(2f * phase) / 2f;
       */
        tf.position = pivot;
    }
}
