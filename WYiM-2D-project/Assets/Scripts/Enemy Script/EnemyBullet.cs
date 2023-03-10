using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float bulletTimeOut;

    private int dmg = 1;


    void OnEnable()
    {
        Invoke("Destroy", bulletTimeOut);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
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
}
