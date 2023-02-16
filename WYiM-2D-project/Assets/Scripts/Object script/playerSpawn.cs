using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawn : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<Transform>().position = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
