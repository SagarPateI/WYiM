using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security;
using UnityEngine;

public class pieCollide : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {

        if (col.CompareTag("Enemy"))
        {
            Debug.Log("Killed a Knight");
            //plan on adding different sounds for if it hits an enemy or wall or different enemy types
        }
        if (!col.CompareTag("EnemyBullet"))
        {
            Object.Destroy(gameObject);
        }
    }
}
