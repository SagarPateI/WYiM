using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InstrucCheckpoint : MonoBehaviour
{
    public string[] instruction;                                             // Take in text instruction and appended into array (String)
    [SerializeField] private int counter = 0;                                // Counter, like i in for loop

    public GameObject instruc_image;                                         // The canvas where it shows the instruction
    public GameObject instruc_text;                                          // The place where the text appear
    public GameObject[] instruc_video;                                     // Array store the instructio videos(clips) (GameObject)
    public Canvas canvas;                                                 //The player canvas
    public GameObject crosshair;

    public float rem;

    private GameObject player;                                               // The player itself

    private bool is_instruc = false;                                         // Boolean to check whether or not it is during instruction
    [SerializeField] private int[] element;                                  // Array that store the position/slide/text where the instruction videos(clips) will appear during instruction

    // Start is called before the first frame update
    void Start()                                                                  // Fun stuffs in Start( a little lazy to comment all)
    {
        player = GameObject.FindWithTag("Player");
        instruc_text.GetComponent<TMP_Text>().text = instruction[counter];
        instruc_image.SetActive(false);
        instruc_text.SetActive(false);
        if (instruc_video != null && PlayerPrefs.GetInt("instructionOption") == 1)
        {
            foreach (GameObject video in instruc_video)
            {
                video.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (is_instruc && PlayerPrefs.GetInt("instructionOption") == 1)                                                       // Check whether is it during instruction
        {
            if (Input.GetKeyDown(KeyCode.Space))                              // Take in input
            {
                counter++;                                                   // Increase counter
            }
            if (counter >= instruction.Length)                                // Check if counter >= the instruction[] length
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                player.GetComponent<FirePie>().enabled = true;
                player.GetComponent<ShieldPowerUp>().setShields(rem);
                canvas.enabled = true;
                crosshair.SetActive(true);
                instruc_image.SetActive(false);                              // If true, then turn off instruction
                instruc_text.SetActive(false);
                if (instruc_video != null)
                {
                    foreach (GameObject video in instruc_video)
                    {
                        video.SetActive(false);
                    }

                }
                Time.timeScale = 1f;
                is_instruc = false;
            }
            else                                                                   // If not, set the text to be the next instruction
            {
                instruc_text.GetComponent<TMP_Text>().text = instruction[counter];
            }
            if (instruc_video != null)                                               // Check if is there any video
            {
                for (int i = 0; i < element.Length; i++)                                 // If yes, then iterate through the array that store the position/slide/text where the videos(clips) suppose to be
                {
                    if (counter == element[i])
                    {
                        instruc_video[i].SetActive(true);                          // Then turn the videos(clips) on
                    }
                    else
                    {
                        instruc_video[i].SetActive(false);                      // If not, then turn the videos(clips) off
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)                               // Check if the player enter the checkpoint where the instructions at
    {
        if (hitInfo.CompareTag("Player") && !is_instruc && PlayerPrefs.GetInt("instructionOption") == 1)
        {
            Debug.Log("player touched this.");
            rem = hitInfo.GetComponent<ShieldPowerUp>().shieldVal();
            hitInfo.GetComponent<PlayerMovement>().enabled = false;
            hitInfo.GetComponent<FirePie>().enabled = false;
            canvas.enabled = false;
            crosshair.SetActive(false);
            instruc_image.SetActive(true);
            instruc_text.SetActive(true);
            Time.timeScale = 0f;
            is_instruc = true;
            GetComponent<BoxCollider2D>().enabled = false;              // Added this to display instructions only 1 time.
        }
    }
}
