using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    public GameObject healObject;
    public PlayerHealth AddHealth;
    int curr, mhp;

    // Start is called before the first frame update
    void Start()
    {
        healObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D hit){
        if(hit.CompareTag("Player")){
            hit.GetComponent<PlayerHealth>().Heal(2);
            Destroy(gameObject);
        }
    }
}
