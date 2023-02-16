using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crosshair : MonoBehaviour
{

    public Transform tf;

    public GameObject main_title_crosshair;
    public GameObject in_game_crosshair1;
    public GameObject in_game_crosshair2;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tf.position = mousePos;
        
        if(SceneManager.GetActiveScene().name == "MainTitle")
        {
            main_title_crosshair.SetActive(true);
            in_game_crosshair1.SetActive(false);
            in_game_crosshair2.SetActive(false);
        }
        else
        {
            main_title_crosshair.SetActive(false);
            in_game_crosshair1.SetActive(true);
            in_game_crosshair2.SetActive(true);
        }
    }
}
