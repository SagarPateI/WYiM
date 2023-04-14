using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float bulletFireRate = 2f;
    public AudioSource throwSound;
    private Renderer rend;

    // Animation
    public Animator animator;

    [SerializeField, Range(0.01f, 2f)]
    float animSpeedControl = 1f;

    //public int bullet; //Check the bullet pool and put in the number(bullet type) this enemy will shoot
    public Transform[] shotPoints;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("animSpeed", animSpeedControl);
        rend = GetComponent<Renderer>();
        InvokeRepeating("Fire", 0f, bulletFireRate);
    }

    private void Fire()
    {
        throwSound.Play();

        // Animation variable: Set IsThrowing to true
        animator.SetBool("IsThrowing", true);
        StartCoroutine(ResetThrowingAnimation());

        if (rend.enabled == true) //enemy script disables renderer when it dies then destroys the object.
        {
            for (int i = 0; i < shotPoints.Length; i++)
            {
                if (bulletsAmount > 0)
                {
                    GameObject bulletInstance;
                    bulletInstance = Instantiate(projectile, shotPoints[i].position, shotPoints[i].rotation);
                    //bulletInstance.GetComponent<Rigidbody2D>().AddForce(shotPoints[i].forward * 500);

                    Vector3 bulletDir = (shotPoints[i].position - transform.position).normalized;
                    bulletInstance.GetComponent<EnemyBullet>().Setup(bulletDir);

                    //bulletsAmount -= 1;
                }
            }
        }
    }

    private IEnumerator ResetThrowingAnimation()
    {
        yield return new WaitForSeconds(0.5f); // wait for half a second
        animator.SetBool("IsThrowing", false);
    }
}
