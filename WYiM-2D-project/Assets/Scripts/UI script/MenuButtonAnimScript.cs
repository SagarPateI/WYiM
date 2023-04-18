using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonAnimScript : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void HoverEnter()
    {
        anim.SetBool("hover", true);
    }
    public void HoverExit()
    {
        anim.SetBool("hover", false);
    }
}
