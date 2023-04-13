using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{

    public float TimeLeft;
    public bool TimerOn = false;
    public TMP_Text TimerText;
    public bool challengeMode;

    public PlayerHealth healthReset;

    int health;
    int run;

    // Start is called before the first frame update
    void Start()
    {
        run = PlayerPrefs.GetInt("GameMode");
        if(run == 1){
            TimerOn = true;
        }
        else{
            TimerText.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn){
            if(TimeLeft > 0){
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else{
                TimeLeft = 0;
                TimerOn = false;
                TimerText.enabled = false;
                GetComponent<PlayerHealth>().outOfTime();
            }
        }

        health = healthReset.getHealth();

        if(health <= 0){
            TimerText.enabled = false;
        }
    }

    public void updateTimer(float currentTime){
        currentTime += 1;

        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void moreTime(){
        TimeLeft += 10f;
    }
}
