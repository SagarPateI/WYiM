using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCylinder : MonoBehaviour
{
    public float speed = 100f; // Rotation speed in degrees per second

    void Update()
    {
        // Rotate the object around the x-axis by "speed" degrees per second
        transform.Rotate(Vector3.down, speed * Time.deltaTime);
    }
}