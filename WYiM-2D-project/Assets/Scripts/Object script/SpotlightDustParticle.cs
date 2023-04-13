using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class SpotlightDustParticle : MonoBehaviour
{
    [SerializeField] private float fadeStartY = 10f; // the Y-axis value where the light rays start to fade out
    [SerializeField] private float fadeEndOffset = 10f; // the offset from fadeStartY where the light rays are fully faded out
    [SerializeField] private float spotlightIntensity = 1f;
    private Light2D spriteLight;
    private Transform playerCamera;

    private void Start()
    {
        spriteLight = GetComponent<Light2D>();
        playerCamera = Camera.main.transform;
    }

    private void LateUpdate()
    {
        // Check if the player's camera is above the fade line
        if (playerCamera.position.y > fadeStartY)
        {
            // Calculate the distance between the camera and the fade start position
            float distanceFromFadeStart = playerCamera.position.y - fadeStartY;

            // Calculate the distance between the fade start and end positions
            float distanceBetweenFadeStartAndEnd = fadeEndOffset;

            // Calculate the fade amount based on the camera's Y position and the distance between the fade start and end positions
            float fadeAmount = Mathf.Clamp01(1f - (distanceFromFadeStart / distanceBetweenFadeStartAndEnd));

            // Fade out the light's shadow and regular intensity based on the fade amount
            spriteLight.shadowIntensity *= 1f - fadeAmount;
            spriteLight.intensity *= 1f - fadeAmount;
        }
        else
        {
            // If the camera is below the fade line, set the shadow and regular intensity to their original values
            spriteLight.shadowIntensity = spotlightIntensity;
            spriteLight.intensity = spotlightIntensity;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a Gizmo line to show the fade start position
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(transform.position.x - 100f, fadeStartY, 0f), new Vector3(transform.position.x + 100f, fadeStartY, 0f));
    }
}
