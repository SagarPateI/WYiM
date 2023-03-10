using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonControl : MonoBehaviour
{
    public int leveltrack = 0;


    public void OnButtonPress()
    {
        SceneManager.LoadScene("Pre-Level");
        leveltrack = 0;

        PlayerPrefs.SetInt("playerMaxHealth", 6);                                         // Set player max health
        PlayerPrefs.SetInt("playerCurrentHealth", PlayerPrefs.GetInt("playerMaxHealth")); // Set player current health to max health
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public int getLevel()
    {
        return leveltrack;
    }
    public void changeLevel()
    {
        leveltrack++;
        Debug.Log(leveltrack);
    }
}