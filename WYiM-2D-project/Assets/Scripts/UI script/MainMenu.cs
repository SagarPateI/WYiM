using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject selectorBox; // Reference to the selector box GameObject
    public float selectorSpeed = 10f; // Speed of the selector box movement

    private int selectedOption = 0; // Index of the currently selected option
    private Vector3[] optionPositions; // Array of the positions of the menu options
    private bool canSelect = true; // Flag to prevent rapid input

    public RectTransform startButton;
    public RectTransform chalButton;
    public RectTransform quitButton;

    private float start_y;
    private float chal_y;
    private float quit_y;

    private float start_up;
    private float start_down;

    private float chal_up;
    private float chal_down;

    private float quit_up;
    private float quit_down;

    void Start()
    {
        // Get the positions of the menu options
        optionPositions = new Vector3[transform.childCount];
        for (int i = 0; i < optionPositions.Length; i++)
        {
            optionPositions[i] = transform.GetChild(i).position;
        }

        start_y = startButton.transform.position.y;
        chal_y = chalButton.transform.position.y;
        quit_y = quitButton.transform.position.y;

        start_up = start_y + startButton.sizeDelta.y/2;
        start_down = start_y - startButton.sizeDelta.y/2;

        chal_up = chal_y + chalButton.sizeDelta.y/2;
        chal_down = chal_y - chalButton.sizeDelta.y/2;

        quit_up = quit_y + quitButton.sizeDelta.y/2;
        quit_down = quit_y - quitButton.sizeDelta.y/2;
    }

    void Update()
    {
        // Move the selector box based on mouse position
        if(Input.mousePosition.y >= start_down && Input.mousePosition.y <= start_up)
        {
            selectorBox.transform.position = new Vector2(selectorBox.transform.position.x, start_y);
        }
        else if(Input.mousePosition.y >= chal_down && Input.mousePosition.y <= chal_up)
        {
            selectorBox.transform.position = new Vector2(selectorBox.transform.position.x, chal_y);
        }
        else if(Input.mousePosition.y >= quit_down && Input.mousePosition.y <= quit_up)
        {
            selectorBox.transform.position = new Vector2(selectorBox.transform.position.x, quit_y);
        }
        else
        {
            selectorBox.transform.position = new Vector2(selectorBox.transform.position.x, -1000);
        }
        

        // Get the index of the currently selected option
        int newSelectedOption = -1;
        for (int i = 0; i < optionPositions.Length; i++)
        {
            if (selectorBox.transform.position == optionPositions[i])
            {
                newSelectedOption = i;
                break;
            }
        }

        // If a new option is selected, update the selectedOption variable
        if (newSelectedOption != -1 && newSelectedOption != selectedOption)
        {
            selectedOption = newSelectedOption;
        }

        // Handle menu option input
        if (canSelect && Input.GetButtonDown("Submit"))
        {
            canSelect = false;

            switch (selectedOption)
            {
                case 0: // Start
                    SceneManager.LoadScene("Game");
                    break;
                case 1: // Challenge Mode
                    SceneManager.LoadScene("ChallengeMode");
                    break;
                case 2: // Options
                    SceneManager.LoadScene("Options");
                    break;
                case 3: // Quit
                    Application.Quit();
                    break;
            }
        }

        // Reset the canSelect flag to prevent rapid input
        if (!canSelect && !Input.GetButtonDown("Submit"))
        {
            canSelect = true;
        }
    }
}
