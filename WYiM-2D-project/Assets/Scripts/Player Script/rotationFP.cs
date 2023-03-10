using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class rotationFP : MonoBehaviour
{
    public Transform tf;
    private GameObject target;

    public float angle;

    private Vector2 playerPos;
    private Vector2 mousePos;
    private Vector3 AngleFP = new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("innerCrosshair");
    }
    void Update()
    {
        mousePos = target.transform.position;
        playerPos = tf.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        
        Vector2 direction = mousePos - playerPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        AngleFP.z =  (angle);
        tf.localEulerAngles = AngleFP;
        
    }
}
