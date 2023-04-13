using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 90f,
        endAngle = 270f; //this determines the arc of how to bullets come out
    private Vector2 bulletMoveDirection;

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

    /* private void Fire()
     {
         throwSound.Play();

         // Animation variable: Set IsThrowing to true
         animator.SetBool("IsThrowing", true);
         StartCoroutine(ResetThrowingAnimation());

         float angleStep = (endAngle - startAngle) / bulletsAmount;
         float angle = startAngle;
         if (rend.enabled == true) //enemy script disables renderer when it dies then destroys the object.
         { //this should make it so that it doesn't shoot bullets even though the sprite is gone.
             for (int i = 0; i < bulletsAmount; i++)
             {
                 float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                 float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                 Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                 Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                 GameObject bul = BulletPool.bulletPoolInstanse.GetBullet(bullet);
                 bul.transform.position = transform.position;
                 bul.transform.rotation = transform.rotation;

                 bul.SetActive(true);
                 bul.GetComponent<EnemyBullet>().SetMoveDirection(bulDir);

                 bul.transform.Rotate(0f, 0f, Mathf.Atan2(bulDir.y, bulDir.x) * Mathf.Rad2Deg);

                 angle += angleStep;
             }
         }
         // Set IsThrowing to false
         // animator.SetBool("IsThrowing", false);
     }*/

    private void Fire()
    {
        throwSound.Play();

        // Animation variable: Set IsThrowing to true
        animator.SetBool("IsThrowing", true);
        StartCoroutine(ResetThrowingAnimation());

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

    private IEnumerator ResetThrowingAnimation()
    {
        yield return new WaitForSeconds(0.5f); // wait for half a second
        animator.SetBool("IsThrowing", false);
    }
}
