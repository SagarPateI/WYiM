using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    //Variables
    public GameObject pauseMenu;
    public GameObject player;

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
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused == true){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        isPaused = false;

        player.GetComponent<PlayerMovement>().enabled = true;
        Time.timeScale = 1f;
    }

    public void Pause(){
        pauseMenu.SetActive(true);
        isPaused = true;

        player.GetComponent<PlayerMovement>().enabled = false;
        Time.timeScale = 0f;
    }


    public void Quit(){
        Application.Quit();
    }

    public void mainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainTitle");
    }
}
