using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float radius = 5f;
    private Vector2 basePoint;      //Position of center of circle
    private Vector2 startPos;       //Position of where enemy currently is
    private Vector2 nextPos;        //Position of where to go next
    private float progress = 0f;    //Current progress of travel

    //version 2
    public GameObject enemy;
    public Transform[] points;
    [SerializeField] private int NextPosIndex;
    [SerializeField] private Transform NextPos;

    public float enemyHorizontalMovement = 0f;                        // Horizontal movement (1 for right/A and -1 for left/D)
    public float enemyVerticalMovement = 0f;

    // Animations things
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //ver 1
        startPos = transform.localPosition;
        basePoint = transform.localPosition;
        progress = 0f;      //just in case it doesnt go to 0 

        //PickNextRandomPosition();

        //ver 2
        NextPos = points[0];
    }

    // Update is called once per frame
    void Update()
    {
        /*//ver 1
        //Enemy should only move to another new position if they reached the first position
        bool reached = false;

        //Update our progress to our destination
        progress += speed * Time.deltaTime;

        //Check for if we go past or reach our destination
        if (progress >= 1.0f)
        {
            progress = 1.0f;
            reached = true;
        }

        //Update our position based on our start postion, destination and progress.
        transform.localPosition = (nextPos * progress) + startPos * (1 - progress);

        //If we have reached the destination, set it as the new start and pick a new random point. Reset the progress
        if (reached)
        {
            startPos = nextPos;
            PickNextRandomPosition();
            progress = 0.0f;
        }*/

        //ver 2
        MoveEnemyToNextPoint();

        enemyHorizontalMovement = Input.GetAxisRaw("Horizontal");
        enemyVerticalMovement = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(enemyHorizontalMovement, enemyVerticalMovement).normalized;
        // Animation variable
        animator.SetFloat("Horizontal", enemyHorizontalMovement);
        animator.SetFloat("Vertical", enemyVerticalMovement);
    }

    //ver 1
    /*void PickNextRandomPosition()
    {
        //Select random point starting from the base point
        nextPos = Random.insideUnitCircle * radius + basePoint;
    }*/

    //ver 2
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
        }
        else
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, NextPos.position, speed * Time.deltaTime);
        }
    }
}
