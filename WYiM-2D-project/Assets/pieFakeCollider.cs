
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class pieFakeCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Wall"))
        {
            Object.Destroy(gameObject);
           
        }
       
    }
}
