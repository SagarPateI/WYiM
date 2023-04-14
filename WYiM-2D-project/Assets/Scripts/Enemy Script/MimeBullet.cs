using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimeBullet : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float bulletFireRate = 2f;
    public AudioSource throwSound;
    private Renderer rend;

    //public int bullet; //Check the bullet pool and put in the number(bullet type) this enemy will shoot
    public Transform[] shotPoints;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, bulletFireRate);
    }

    private void Fire()
    {
        throwSound.Play();
        for (int i = 0; i < shotPoints.Length; i++)
        {
            if (bulletsAmount > 0)
            {
                GameObject bulletInstance;
                bulletInstance = Instantiate(projectile, shotPoints[i].position, shotPoints[i].rotation);

                Vector3 bulletDir = (shotPoints[i].position - transform.position).normalized;
                bulletInstance.GetComponent<EnemyBullet>().Setup(bulletDir);
            }
        }
    }
}
