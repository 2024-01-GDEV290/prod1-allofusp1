using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightningEffect : MonoBehaviour
{
    public float minFlashInterval = 5.0f; // Minimum time between flashes
    public float maxFlashInterval = 10.0f; // Maximum time between flashes
    public float flashDuration = 0.2f; // Duration of the lightning flash
    public float lightIntensity = 0.0f; // Initial intensity of the light
    public float maxIntensity = 5.0f; // Maximum intensity of the light during flash
    public float flickerIntensity = 1.0f; // Intensity of flickering after flash
    public float flickerDuration = 0.1f; // Duration of flickering after flash
    public float flickerSpeed = 10.0f; // Speed of flickering
    public List<Light> lightningLights; // List of lights to be affected by the lightning effect

    private bool isFlashing = false;

    void Start()
    {
        // Start the flashing coroutine
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        while (true)
        {
            // Wait for random interval
            yield return new WaitForSeconds(Random.Range(minFlashInterval, maxFlashInterval));

            // Flash the lights
            StartCoroutine(FlashLights());
        }
    }

    IEnumerator FlashLights()
    {
        // Turn on the lights during flash
        foreach (Light light in lightningLights)
        {
            light.intensity = lightIntensity;
        }

        // Increase light intensity during flash
        float startTime = Time.time;
        while (Time.time < startTime + flashDuration)
        {
            float t = (Time.time - startTime) / flashDuration;
            foreach (Light light in lightningLights)
            {
                light.intensity = Mathf.Lerp(lightIntensity, maxIntensity, t);
            }
            yield return null;
        }

        // Flicker the lights
        foreach (Light light in lightningLights)
        {
            StartCoroutine(FlickerLight(light));
        }
    }

    IEnumerator FlickerLight(Light light)
    {
        // Wait for the flash duration
        yield return new WaitForSeconds(flashDuration);

        float originalIntensity = light.intensity;
        float flickerTime = 0;

        // Flicker the lights
        while (flickerTime < flickerDuration)
        {
            // Flicker the light intensity randomly
            light.intensity = Random.Range(originalIntensity - flickerIntensity, originalIntensity + flickerIntensity);
            flickerTime += Time.deltaTime * flickerSpeed;
            yield return null;
        }

        // Reset the light intensity
        light.intensity = lightIntensity;
    }
}
