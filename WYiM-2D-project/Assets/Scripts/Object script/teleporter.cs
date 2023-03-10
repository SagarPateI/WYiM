using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleporter : MonoBehaviour
{
    public string levelName;
    [SerializeField] public ButtonControl buttons;

    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Player"))
        {
            LoadLevel();
        }
    }
}
