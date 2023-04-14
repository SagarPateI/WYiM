using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lightning : MonoBehaviour
{
    public SpriteRenderer lightningSprite;
    public AudioSource thunderSound;
    public Light2D spriteLight;
    public float minTime = 1.0f;
    public float maxTime = 5.0f;
    public float lightIntensity = 1.0f;
    public float lightDuration = 0.1f;
    public float timeBetweenFlashes = 0.2f;

    private void Start()
    {
        // disable lightning sprite and lightning light at the start
        lightningSprite.enabled = false;
        spriteLight.enabled = false;

        StartCoroutine(LightningFlash());
    }

    IEnumerator LightningFlash()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            // 1st lightning flash
            lightningSprite.enabled = true;
            spriteLight.intensity = lightIntensity;
            spriteLight.enabled = true;
            thunderSound.Play();
            yield return new WaitForSeconds(lightDuration);
            lightningSprite.enabled = false;
            spriteLight.enabled = false;

            // pause before second flash
            yield return new WaitForSeconds(timeBetweenFlashes);

            // 2nd lightning flash
            lightningSprite.enabled = true;
            spriteLight.intensity = lightIntensity;
            spriteLight.enabled = true;
            thunderSound.Play();
            yield return new WaitForSeconds(lightDuration);
            lightningSprite.enabled = false;
            spriteLight.enabled = false;
        }
    }
}