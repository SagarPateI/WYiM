using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crosshair : MonoBehaviour
{

    public Transform tf;


    public PauseMenu pause;
    public GameObject player;
    //public PlayerHealth health; // Causing null reference errors. See below
    public GameObject health;
    private PlayerHealth playerHealth;


    public int Health;

    public GameObject main_title_crosshair;
    public GameObject in_game_crosshair1;
    public GameObject in_game_crosshair2;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Get the position of the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Set the crosshair position to the mouse position
        tf.position = (mousePos);
        //Health = health.getHealth(); //Causing null reference errors
        playerHealth = health.GetComponent<PlayerHealth>(); // I'm adding this to access the health - Sagar
        Health = playerHealth.getHealth();



        isPaused = pause.getPaused();
        if (SceneManager.GetActiveScene().name == "MainTitle" || isPaused || Health <= 0)
        {
            Cursor.visible = true;
            main_title_crosshair.SetActive(true);
            in_game_crosshair1.SetActive(false);
            in_game_crosshair2.SetActive(false);
            player.GetComponent<FirePie>().enabled = false;
        }
        else
        {
            main_title_crosshair.SetActive(false);
            in_game_crosshair1.SetActive(true);
            in_game_crosshair2.SetActive(true);
            player.GetComponent<FirePie>().enabled = true;
            Cursor.visible = false;
        }
    }
}
