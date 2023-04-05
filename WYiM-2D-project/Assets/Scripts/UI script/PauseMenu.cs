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

    public static bool isPaused = false;
    public float trans = 1f;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
            SceneManager.LoadScene("MainTitle");
        }

        if(health <= 0){
            PieCounter.text = " ";
        }

        if(Input.GetKeyDown(KeyCode.K)){
            DeathScreen();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }


    public void Quit(){ //Quits game
        Application.Quit();
    }

    public void mainMenu(){ //Management for returning title screen
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainTitle");
    }

    public void PiesCounter(){ //Pie Counter manager
        PieCounter.text = "Pies: " + pies.ToString();
    }

    public bool getPaused(){
        return isPaused;
    }

    public int getPieNum(){
        return pies;
    }

    public void usePie(){
        pies--;
        Debug.Log("Pie Used" + pies);
    }

    public void refillPies(int add){
        pies += add;
        Debug.Log("Number of Pies Added: " + add);
    }
}
