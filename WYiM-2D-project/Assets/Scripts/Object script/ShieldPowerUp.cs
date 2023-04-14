using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldPowerUp : MonoBehaviour
{

    public bool shieldsUp;

    public PlayerHealth healthReset;

    int health;

    public Slider shields;

    public void maxShield(){//Set shield value when activated
        shields.value = 5;
    }

    public void decrementShield(int d){ //Take off amount of equivalent health health from shield when hit
        shields.value -= d;
        if(shields.value <= 0){ //Deactivate shield if less than zero (cheekily, this means that the amount of damage that can be sponged is actually 6)
            shieldsUp = false;
            GetComponent<HUD>().has_shield = false;
        }
    }

    public void activateShields(){
        shieldsUp = true; //Activate shields 
        maxShield();
    }

    public void setShields(float k){
        shields.value = k;
    }

    public bool getShields(){
        return shieldsUp;
    }
    public float shieldVal(){
        return shields.value;
    }

    // Start is called before the first frame update
    void Start() //Get shield object and initialize needed variables
    {
        shields = GameObject.Find("ShieldBar").GetComponent<Slider>();
        shields.value = 0;
        shieldsUp = false;
    }

    void Update(){
        health = healthReset.getHealth();

        if(health > 0){//Disable shield bar when player dies
            shields.gameObject.SetActive(true);
        }
        else{
            shields.gameObject.SetActive(false);
        }
    }
}
