using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InsultDiedText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private string[] insulttext;
    public bool text_set = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(!text_set){
            int num = Random.Range(0, insulttext.Length-1);
            text.text = insulttext[num];
            text_set = true;
        }
            
    }
}
