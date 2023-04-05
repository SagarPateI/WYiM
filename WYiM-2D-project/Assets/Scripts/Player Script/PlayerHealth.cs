using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    private Scene scene;

    [SerializeField] private PlayerMovement playerMov;

    public bool Dash;

    public int healthPerHeart = 2;

    public Slider[] hearts;
    public GameObject diedImage;
    public GameObject playAgainbutton;
    public AudioSource hitSound;

    public Sprite[] hearts_sprite;
    public Image[] hearts_image;

    // Start is called before the first frame update
    public void Start()
    {
        maxHealth = PlayerPrefs.GetInt("playerMaxHealth");
        currentHealth = PlayerPrefs.GetInt("playerCurrentHealth");
        currentHealth = maxHealth;
        playerMov = GetComponent<PlayerMovement>();
        diedImage.SetActive(false);
        playAgainbutton.SetActive(false);
        Dash = playerMov.dashCheck();
        scene = SceneManager.GetActiveScene();
        Debug.Log(maxHealth);
    }

    // Update is called once per frame
    public void Update()
    {
        Dash = playerMov.dashCheck();
        UpdateHealthBar();
    }

    public void takeDamage(int damage)                             // Function for taking damage
    {
        if (scene.name == "Level 1")
        {
            if (Dash == false)
            {
                //sound here
                hitSound.Play();
                currentHealth -= (damage*2);                                  // Reduce current health
                PlayerPrefs.SetInt("playerCurrentHealth", currentHealth); // Store current health
                UpdateHealthBar();
                if (currentHealth <= 0)
                {
                    // If current health is <= 0, then do these
                    diedImage.SetActive(true);
                    playAgainbutton.SetActive(true);
                    Time.timeScale = 0f;
                }
                Debug.Log(damage);
                Debug.Log(currentHealth);
            }
            else
            {
               Debug.Log("Rolling");
                return;
            }

        }
        else
        {

            if (Dash == false)
            {
                //sound here
                hitSound.Play();
                currentHealth -= damage;                                  // Reduce current health
                PlayerPrefs.SetInt("playerCurrentHealth", currentHealth); // Store current health
                UpdateHealthBar();
                if (currentHealth <= 0)
                {
                    // If current health is <= 0, then do these
                    diedImage.SetActive(true);
                    playAgainbutton.SetActive(true);
                    Time.timeScale = 0f;
                }
                Debug.Log(damage);
                Debug.Log(currentHealth);
            }
            else
            {
                Debug.Log("Rolling");
                return;
            }
        }
    }

    public void Heal(int health)                                        //Function for healing
    {
        //int ch = getHealth();
        currentHealth += health;
        if(maxHealth - currentHealth <= 1){
            currentHealth = maxHealth;
        }    
        else{ // Otherwise, set current health += the amount of healing
            currentHealth += health;
        }
        PlayerPrefs.SetInt("playerCurrentHealth", currentHealth);  // Store current health
        UpdateHealthBar();
    }

    public void UpdateHealthBar()                                // Function for update the UI of health bar
    {
        int hp = currentHealth;                          // Counter for current health
        foreach (Slider heart in hearts)
        {
            heart.value = 0;                             // Reset the heart
        }

        for (int i = 0; i < hearts.Length; i++)          //Iterate through the hearts array
        {
            if (hp >= healthPerHeart)                    // If the counter is >= health per heart, then assign the max value (2)
            {
                hearts[i].value = healthPerHeart;
                hearts_image[i].sprite = hearts_sprite[2];

            }
            else                                        // Otherwise, assign whatever left in the counter
            {
                hearts[i].value = hp;
                if (hearts[i].value == 0)
                {
                    hearts_image[i].sprite = hearts_sprite[0];
                }
                else
                {
                    hearts_image[i].sprite = hearts_sprite[1];
                }
            }
            if (hp >= 0)                                 //This part is just to prevent the counter to reach below 0
            {
                hp -= healthPerHeart;
            }
            else
            {
                hp = 0;
            }
        }
    }

    public int getHealth()
    {
        return currentHealth;
    }
    public int getMaxHealth(){
        return maxHealth;
    }

    public void reset(){
        currentHealth = maxHealth;
        playerMov = GetComponent<PlayerMovement>();
        Dash = playerMov.dashCheck();
    }
}
