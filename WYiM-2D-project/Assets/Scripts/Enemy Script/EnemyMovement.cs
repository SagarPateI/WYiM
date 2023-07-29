using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;

    public GameObject enemy;
    public Transform[] points;
    [SerializeField] private int NextPosIndex;
    [SerializeField] private Transform NextPos;
    bool pause = false;

    // Animations things
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the start point
        NextPos = points[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(pause) return;
        MoveEnemyToNextPoint();
    }

    void MoveEnemyToNextPoint()
    {
        if (enemy.transform.position == NextPos.position)
        {
            NextPosIndex++;
            if (NextPosIndex >= points.Length)
            {
                //reset
                NextPosIndex = 0;
            }
            NextPos = points[NextPosIndex];
            animator.SetInteger("direction", NextPosIndex);
            StartCoroutine(delay());
        }
        else
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, NextPos.position, speed * Time.deltaTime);
            animator.SetInteger("direction", NextPosIndex);
        }
    }

    IEnumerator delay(){
        pause = true;
        yield return new WaitForSeconds(1f);
        pause = false;
    }
}
