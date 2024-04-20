using UnityEngine;

public class CandleLight : MonoBehaviour
{
    public float flickerSpeed = 1.0f; // Speed of flickering
    public float flickerIntensity = 0.2f; // Intensity of flickering
    public float movementSpeed = 0.5f; // Speed of movement
    public float movementAmount = 0.5f; // Amount of movement

    private Vector3 initialPosition;
    private Light spotlight;

    void Start()
    {
        spotlight = GetComponent<Light>();
        initialPosition = transform.position;

        // Invoke the Flicker function repeatedly
        InvokeRepeating("Flicker", 0f, flickerSpeed);
    }

    void Update()
    {
        // Move the spotlight slightly using Perlin noise
        float xMovement = Mathf.PerlinNoise(Time.time * movementSpeed, 0) * movementAmount;
        float yMovement = Mathf.PerlinNoise(0, Time.time * movementSpeed) * movementAmount;
        transform.position = initialPosition + new Vector3(xMovement, yMovement, 0);
    }

    void Flicker()
    {
        // Randomly change the intensity of the spotlight within a range
        spotlight.intensity = Random.Range(spotlight.intensity - flickerIntensity, spotlight.intensity + flickerIntensity);
    }
}
