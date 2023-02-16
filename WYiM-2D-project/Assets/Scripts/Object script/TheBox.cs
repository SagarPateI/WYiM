using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
//using UnityEditor;
//using UnityEditor.Animations;

public class TheBox : MonoBehaviour
{
    public RuntimeAnimatorController special;
    public RuntimeAnimatorController normal;

    private bool is_special = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Player"))
        {
            hitInfo.GetComponent<Animator>().runtimeAnimatorController = special;
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Player"))
        {
            hitInfo.GetComponent<Animator>().runtimeAnimatorController = normal;
        }
    }
}
