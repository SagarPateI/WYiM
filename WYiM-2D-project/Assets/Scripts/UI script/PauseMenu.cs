using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    //Variables
    public GameObject pauseMenu;
    public GameObject player;
    public GameObject deathScreen;
    public GameObject restartButton;

    public FirePie pieCounter;
    public PlayerHealth healthReset;
    public playerSpawn reSpawn;

    public TMP_Text PieCounter;
    public int pies;

    int health;
    int instructHotKey;

    public static bool isPaused = false;
    public float trans = 1f;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        PlayerPrefs.SetInt("PieAmmo", pies);
        instructHotKey = PlayerPrefs.GetInt("instructionOption");

        PieCounter.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        pies = PlayerPrefs.GetInt("PieAmmo");
        health = healthReset.getHealth();

        if(Input.GetKeyDown(KeyCode.Escape)){ //Pause menu
            if(isPaused == true){
                Resume();
            }
            else{
                Pause();
            }
        }

        if(Input.GetKeyDown(KeyCode.L)){ //Escape key to return to main title screen
            SceneManager.LoadScene("MainMenu");
        }

        if(health <= 0){
            PieCounter.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.K)){
            DeathScreen();
        }

        if(Input.GetKeyDown(KeyCode.P)){
            if(PlayerPrefs.GetInt("instructionOption") == 1){
                PlayerPrefs.SetInt("instructionOption", 0);
            }
            else{
                PlayerPrefs.SetInt("instructionOption", 1);
            }
        }

        PiesCounter();
    }

    public void Resume(){ //Resume game components
        pauseMenu.SetActive(false);
        isPaused = false;

        player.GetComponent<PlayerMovement>().enabled = true;
        Time.timeScale = 1f;
    }

    public void Pause(){ //Pause Components
        pauseMenu.SetActive(true);
        isPaused = true;

        player.GetComponent<PlayerMovement>().enabled = false;
        Time.timeScale = 0f;
    }

    public void DeathScreen(){
        player.GetComponent<PlayerHealth>().reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("playerCurrentHealth", PlayerPrefs.GetInt("playerMaxHealth"));
        PlayerPrefs.SetInt("instructionOption", 0);
        player.GetComponent<InsultDiedText>().text_set = false;
        Time.timeScale = 1f;
    }


    public void Quit(){ //Quits game
        Application.Quit();
    }

    public void mainMenu(){ //Management for returning title screen
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void PiesCounter(){ //Pie Counter manager
        PieCounter.text = pies.ToString();
    }

    public bool getPaused(){
        return isPaused;
    }
}
