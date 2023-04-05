using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using UnityEngine;

public class powerPickup : MonoBehaviour
{
    public GameObject Ab;
    public GameObject aim;
    public AimBounce Abounce; 
    
    // Start is called before the first frame update
    void Start()
    {
        Ab =GameObject.Find("sniper");
        Abounce = GameObject.Find("Crosshair").GetComponent<AimBounce>();
        
        
        
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("sniper"))
        {
            Abounce.sniperMode();
            Object.Destroy(Ab);
            
        }
    }
}


