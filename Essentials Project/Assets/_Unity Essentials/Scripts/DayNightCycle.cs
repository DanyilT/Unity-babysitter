using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Number of real seconds for a full in-game day
    [Tooltip("Number of real seconds for a full day to pass.")]
    public float dayLengthInSeconds = 120f; // Default to 120 seconds for a full day

    // Start rotation angle
    private float rotationSpeed;

    void Start()
    {
        // Calculate the rotation speed based on how many degrees per second the light should rotate
        // A full day is 360 degrees, so divide that by the total seconds in a day
        rotationSpeed = 360f / dayLengthInSeconds;
    }

    void Update()
    {
        // Rotate the light around the X axis to simulate the sun moving
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
