// Currently testing this script. Feel free to add changes.
// - Sagar
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    public float smoothing;

    // Allows us to set the limits of the camera so that the camera stays in the level
    [SerializeField]
    float leftBound, rightBound, topBound, bottomBound;

    void FixedUpdate()
    {
        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, smoothing);
        
        // Limit the camera to these boundaries in the x and y directions
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBound, rightBound), Mathf.Clamp(transform.position.y, bottomBound, topBound), transform.position.z);
    }

    // Draw a green box to show the camera's boundaries that you set
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector2(leftBound, topBound), new Vector2(rightBound, topBound));
        Gizmos.DrawLine(new Vector2(rightBound, bottomBound), new Vector2(leftBound, bottomBound));
        Gizmos.DrawLine(new Vector2(rightBound, topBound), new Vector2(rightBound, bottomBound));
        Gizmos.DrawLine(new Vector2(leftBound, topBound), new Vector2(leftBound, bottomBound));
    }
}
