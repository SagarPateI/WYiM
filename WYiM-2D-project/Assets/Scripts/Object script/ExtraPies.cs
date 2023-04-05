using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPies : MonoBehaviour
{
    public GameObject PieAdder;
    public PauseMenu addFunction;

    public int num;

    // Start is called before the first frame update
    void Start()
    {
        PieAdder.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.CompareTag("Player"))
        {
            addFunction.refillPies(num);
            Destroy(PieAdder);
        }
    }
}
