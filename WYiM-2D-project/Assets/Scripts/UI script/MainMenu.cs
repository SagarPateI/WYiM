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

    void Start()
    {
        // Get the positions of the menu options
        optionPositions = new Vector3[transform.childCount];
        for (int i = 0; i < optionPositions.Length; i++)
        {
            optionPositions[i] = transform.GetChild(i).position;
        }
    }

    void Update()
    {
        // Move the selector box based on mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        selectorBox.transform.position = Vector3.MoveTowards(selectorBox.transform.position, mousePos, selectorSpeed * Time.deltaTime);

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
