using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayCutscenes : MonoBehaviour
{
    public VideoClip[] narratorClips;
    public VideoPlayer mainPlayer;
    public int currentClip = 0;
    private float timeUntilNextVideo;
    public bool firstCutscene = true;

    // Start is called before the first frame update
    void Start()
    {
        mainPlayer = GetComponent<VideoPlayer>();
        mainPlayer.clip = narratorClips[0];
        timeUntilNextVideo = 0; 
    }


    void Update()
    {
        if (Time.time > timeUntilNextVideo)
        {
            mainPlayer.clip = narratorClips[currentClip];
            currentClip++;
            timeUntilNextVideo = Time.time + (float)mainPlayer.clip.length;
            mainPlayer.Play();
        }
        if(firstCutscene)
        {
            StartCoroutine(GoToPreLevel());
        }
        if (!firstCutscene)
            StartCoroutine(GoToCredits());
    }
    public IEnumerator GoToPreLevel()
    {
        yield return new WaitForSeconds(49f);
        SceneManager.LoadScene("Pre-Level");
    }
    public IEnumerator GoToCredits()
    {
        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene("CreditsScene");
    }
}
