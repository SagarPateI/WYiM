using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float bulletTimeOut;
    [SerializeField] private Rigidbody2D rb;

    private int dmg = 1;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            dmg = 2;
        }
        else
        {
            dmg = 1;
        }
    }

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Destroy", bulletTimeOut);
    }

    public void Setup(Vector3 bulletDir)
    {
        rb.AddForce(bulletDir * moveSpeed, ForceMode2D.Impulse);
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(bulletDir));
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            hitInfo.GetComponent<PlayerHealth>().takeDamage(dmg);
            Destroy();
        }
        else if (hitInfo.CompareTag("Wall"))
        {
            Destroy();
        }
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
            n += 360;
        return n;
    }
}
