using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audio;
    public AudioClip footstep;
    bool isMoving;

    private float move_speed = 2.5f;                               // Set the move speed of the player
    private float horizontalMovement = 0f;                        // Horizontal movement (1 for right/A and -1 for left/D)
    private float verticalMovement = 0f;                          // Vertical movement (1 for up/W and -1 for down/S)

    // Dash/Roll stuffs (a little bit lazy to comment them)
    private float dash_time = 0.1f;
    [SerializeField] private float dash_power = 2f;
    private float dash_cd;
    private float dash_cd_time = 4f;
    private bool is_dash_cd = false;
    private bool is_dashing = false;
    public Sprite[] dash_image_cd;
    public Image dash_image;
    public TMP_Text dash_text;

    // Animations things
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        dash_cd = dash_cd_time;
        dash_image.sprite = dash_image_cd[4];
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(horizontalMovement, verticalMovement).normalized;
        rb.velocity = new Vector2(dir.x * move_speed, dir.y * move_speed);

        if (Mathf.Abs(rb.velocity.x) > 0.1f || Mathf.Abs(rb.velocity.y) > 0.1f)     //All of this is so the audio plays when player is moving
            isMoving = true;
        else
            isMoving = false;
        if (isMoving)
        {
            if (!audio.isPlaying)
                audio.Play();
        }
        else
            audio.Stop();

        // Animation variable
        animator.SetFloat("Horizontal", horizontalMovement);
        animator.SetFloat("Vertical", verticalMovement);

        if (Input.GetKeyDown(KeyCode.E) && (Mathf.Abs(horizontalMovement) > 0 || Mathf.Abs(verticalMovement) > 0) && !is_dashing && !is_dash_cd) // Dash stuff
        {
            StartCoroutine(Dash());
            is_dash_cd = true;
            dash_image.sprite = dash_image_cd[Mathf.RoundToInt(dash_cd * 10) / 10];
            dash_text.text = ((Mathf.RoundToInt(dash_cd * 10) / 10)+1).ToString();
        }
        if (is_dash_cd)
        {
            dash_cd -= Time.deltaTime;
            dash_image.sprite = dash_image_cd[Mathf.RoundToInt(dash_cd * 10) / 10];
            dash_text.text = ((Mathf.RoundToInt(dash_cd * 10) / 10)+1).ToString();
        }
        if (dash_cd <= 0f)
        {
            dash_cd = dash_cd_time;
            is_dash_cd = false;
            dash_image.sprite = dash_image_cd[4];
            dash_text.text = "";
        }

    }

    IEnumerator Dash()
    {
        move_speed *= dash_power;
        is_dashing = true;
        animator.SetBool("Roll", is_dashing);
        int LayerIgnore = LayerMask.NameToLayer("PlayerRoll");
        gameObject.layer = LayerIgnore;

        yield return new WaitForSeconds(dash_time);

        move_speed /= dash_power;
        is_dashing = false;
        animator.SetBool("Roll", is_dashing);
        int Layerfix = LayerMask.NameToLayer("Player");
        gameObject.layer = Layerfix;
    }

    public bool dashCheck()
    {
        return is_dashing;
    }
}
