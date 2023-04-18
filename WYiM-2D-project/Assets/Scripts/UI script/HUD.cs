using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject hud_powerup; //HUD for the power-ups
    [SerializeField] private GameObject clock; //clock power-up
    [SerializeField] private GameObject shield; //shield power-up
    [SerializeField] private GameObject bell; //bell power-up

    public bool has_clock = false; //check to see if has clock power-up
    public bool has_shield = false; //check to see if has shield power-up
    public bool has_bell = false; //check to see if has bell power-up

    private bool hud_drop = false; //check to see if hud_sign had dropped

    private float time = 2f; //time to drop down the HUD_sign
    private float timer = 0f; //timer

    void Start()
    {
        hud_powerup.SetActive(false);
        clock.SetActive(false);
        
        bell.SetActive(false);

        if(!GetComponent<ShieldPowerUp>().getShields())
        {
            shield.SetActive(false);
        }
        else
        {
            shield.SetActive(true);
            has_shield = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!hud_drop && has_shield)
        {
            hud_powerup.SetActive(true);
            hud_drop = true;
        }

        if(has_shield)
        {
            shield.SetActive(true);
        }

        if(hud_drop && !has_shield)
        {
            hud_powerup.SetActive(false);
            hud_drop = false;
        }

    }

}
