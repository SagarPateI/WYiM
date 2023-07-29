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

    public Animator animator;

    [SerializeField] private PlayerMovement playerMov;
    [SerializeField] private ShieldPowerUp shields;

    public bool Dash;
    public bool shieldsUp;
    private bool Imm; //Immunity to prevent double hits

    public int healthPerHeart = 2;

    public Slider[] hearts;
    public GameObject diedImage;
    public GameObject playAgainbutton;
    public GameObject MainMenubutton;
    public GameObject HUD;
    public AudioSource hitSound;

    public Sprite[] hearts_sprite;
    public Image[] hearts_image;

    // Start is called before the first frame update
    public void Start()
    {
        maxHealth = PlayerPrefs.GetInt("playerMaxHealth");
        currentHealth = PlayerPrefs.GetInt("playerCurrentHealth");
        Imm = false;
        playerMov = GetComponent<PlayerMovement>();
        diedImage.SetActive(false);
        playAgainbutton.SetActive(false);
        MainMenubutton.SetActive(false);
        Dash = playerMov.dashCheck();
        Debug.Log(maxHealth);
    }

    // Update is called once per frame
    public void Update()
    {
        Dash = playerMov.dashCheck();
        shieldsUp = GetComponent<ShieldPowerUp>().getShields();
        UpdateHealthBar();
        if(currentHealth > 0)
        {
            HUD.SetActive(true);
        }
        else
        {
            HUD.SetActive(false);
        }
    }

    public void takeDamage(int damage)                             // Function for taking damage
    {
        if (!Dash && !shieldsUp && !Imm)
        {
            //sound here
            hitSound.Play();
            currentHealth -= (damage);                                  // Reduce current health
            PlayerPrefs.SetInt("playerCurrentHealth", currentHealth); // Store current health
            UpdateHealthBar();
            if (currentHealth <= 0)
            {
                // If current health is <= 0, then do these
                diedImage.SetActive(true);
                playAgainbutton.SetActive(true);
                MainMenubutton.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        else if(!Dash && shieldsUp)
        { //Case of not rolling, but with shield power up, do damage to shields instead
            GetComponent<ShieldPowerUp>().decrementShield(damage);
        }
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * 500f);
        StartCoroutine(immunity());

        
    }

    public void Heal(int health)                                        //Function for healing
    {
        if(currentHealth >= 4){
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

    public void outOfTime(){
        currentHealth = 0;
        PlayerPrefs.SetInt("playerCurrentHealth", currentHealth);
        takeDamage(0);
    }

    public void reset(){
        currentHealth = maxHealth;
        playerMov = GetComponent<PlayerMovement>();
        Dash = playerMov.dashCheck();
    }

    IEnumerator immunity(){
        Imm = true;
        animator.SetBool("Immune", Imm);

        yield return new WaitForSeconds(1.5f);

        Imm = false;
        animator.SetBool("Immune", Imm);
    }
}
