using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private int bulletsAmount = 10;
    [SerializeField] private float startAngle = 90f, endAngle = 270f; //this determines the arc of how to bullets come out
    private Vector2 bulletMoveDirection;
    [SerializeField] private float bulletFireRate = 2f;
    public AudioSource throwSound;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        InvokeRepeating("Fire", 0f, bulletFireRate);
    }

    private void Fire()
    {
        throwSound.Play();
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;
        if (rend.enabled == true)       //enemy script disables renderer when it dies then destroys the object. 
        {                               //this should make it so that it doesn't shoot bullets even though the sprite is gone.
            for (int i = 0; i < bulletsAmount; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                
                bul.SetActive(true);
                bul.GetComponent<EnemyBullet>().SetMoveDirection(bulDir);

                angle += angleStep;
            }
        }
    }
}
