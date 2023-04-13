using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlisteningLightRays : MonoBehaviour
{
    [SerializeField] private float offsetSpeed = 1f;
    [SerializeField] private float maxOffset = 0.1f;
    [SerializeField] private float fadeStartY = 10f; // the Y-axis value where the light rays start to fade out
    [SerializeField] private float fadeEndOffset = 10f; // the offset from fadeStartY where the light rays are fully faded out
    private float currentOffset = 0f;
    private Light2D spriteLight;
    private Transform playerCamera;

    private void Start()
    {
        spriteLight = GetComponent<Light2D>();
        playerCamera = Camera.main.transform;
    }

    private void Update()
    {
        // Calculate the new offset based on the current time and speed
        currentOffset = Mathf.Sin(Time.time * offsetSpeed) * maxOffset;

        // Apply the offset to the light's shadow and regular intensity
        spriteLight.shadowIntensity = currentOffset;
        spriteLight.intensity = 1f + currentOffset;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a Gizmo line to show the fade start position
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(transform.position.x - 100f, fadeStartY, 0f), new Vector3(transform.position.x + 100f, fadeStartY, 0f));
    }

    private void LateUpdate()
    {
        // Check if the player's camera is above the fade line
        if (playerCamera.position.y > fadeStartY)
        {
            // Calculate the fade amount based on the camera's Y position and the fade start and end positions
            float fadeAmount = Mathf.Clamp01((playerCamera.position.y - fadeStartY) / fadeEndOffset);

            // Fade out the light's shadow and regular intensity based on the fade amount
            spriteLight.shadowIntensity *= 1f - fadeAmount;
            spriteLight.intensity *= 1f - fadeAmount;
        }
    }
}