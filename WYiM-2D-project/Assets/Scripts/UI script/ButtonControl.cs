using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonControl : MonoBehaviour
{
    public GameObject regPlayButton;
    public GameObject chalButton;
    public GameObject quitButton;
    public GameObject optionsButton;

    public GameObject optionsScreen;
    public Toggle instructToggle;
    bool optionsClose = false;

    //public TMP_Text title;

    void Start(){
        optionsScreen.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && optionsClose){
            optionsScreen.SetActive(false);
            optionsClose = false;
        }
    }

    public void OnButtonPress()
    {
        if(instructToggle.isOn){
            PlayerPrefs.SetInt("instructionOption", 1);
        }
        else{
            PlayerPrefs.SetInt("instructionOption", 0);
        }

        SceneManager.LoadScene("Pre-Level");

        PlayerPrefs.SetInt("GameMode", 0);

        PlayerPrefs.SetInt("playerMaxHealth", 6);                                         // Set player max health
        PlayerPrefs.SetInt("playerCurrentHealth", PlayerPrefs.GetInt("playerMaxHealth")); // Set player current health to max health
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void challengeMode(){
        if(instructToggle.isOn){
            PlayerPrefs.SetInt("instructionOption", 1);
        }
        else{
            PlayerPrefs.SetInt("instructionOption", 0);
        }

        SceneManager.LoadScene("Pre-Level");

        PlayerPrefs.SetInt("GameMode", 1);

        PlayerPrefs.SetInt("playerMaxHealth", 6);                                         // Set player max health
        PlayerPrefs.SetInt("playerCurrentHealth", PlayerPrefs.GetInt("playerMaxHealth")); // Set player current health to max health
        Time.timeScale = 1f;
    }

    public void options(){
        optionsScreen.SetActive(true);
        optionsClose = true;
    }

    public void InstructToggle(){
        if(instructToggle.isOn){
            PlayerPrefs.SetInt("instructionOption", 1);
        }
        else{
            PlayerPrefs.SetInt("instructionOption", 0);
        }
    }
}