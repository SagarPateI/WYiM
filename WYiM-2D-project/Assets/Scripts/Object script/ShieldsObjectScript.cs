using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldsObjectScript : MonoBehaviour
{

    public GameObject shieldObject;
    public ShieldPowerUp shieldScript;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D hit){
        if(hit.CompareTag("Player")){
            hit.GetComponent<ShieldPowerUp>().activateShields();
            hit.GetComponent<HUD>().has_shield = true;
            Destroy(gameObject);
        }
    }
}
