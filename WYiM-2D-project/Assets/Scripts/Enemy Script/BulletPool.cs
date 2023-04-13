using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    /*public static BulletPool bulletPoolInstanse;

    [SerializeField] private GameObject[] pooledBullet;
    private bool notEnoughBulletsInPool = true;
    private List<GameObject> bullets;

    private void Awake()
    {
        bulletPoolInstanse = this;
    }

    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet(int bullet)
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                    return bullets[i];
            }
        }
        if (notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(pooledBullet[bullet], transform.position, Quaternion.identity);
            //pooledBullet.transform.Rotate(0f, 0f, Mathf.Atan2(projectileMoveDirection.y, projectileMoveDirection.x) * Mathf.Rad2Deg);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }*/

    public GameObject[] pooledBullet;
}
