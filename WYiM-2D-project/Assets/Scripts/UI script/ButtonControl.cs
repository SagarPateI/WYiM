using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonControl : MonoBehaviour
{
    public void OnButtonPress(){
        SceneManager.LoadScene("Pre-Level");

        PlayerPrefs.SetInt("playerMaxHealth", 6);                                         // Set player max health
        PlayerPrefs.SetInt("playerCurrentHealth", PlayerPrefs.GetInt("playerMaxHealth")); // Set player current health to max health
        Time.timeScale = 1f;
    }

    public void Quit(){
        Application.Quit();
    }
}