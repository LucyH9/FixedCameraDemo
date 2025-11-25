using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FlickeringLight : MonoBehaviour
{

    private Light LighttoFlicker;
    [SerializeField, Range(0f, 3f)] private float minIntensity = 0.5f;
    [SerializeField, Range(0f, 3f)] private float maxIntensity = 1.2f;
    [SerializeField, Min(0f)] private float timeBetweenIntensity = 0.5f;
    private float currentTimer;

    private void Awake()
    {
        if (LighttoFlicker == null) {
            LighttoFlicker = GetComponent<Light>();
        }
        ValidateIntensityBounds();
    }

    private void Update()
    {
        currentTimer += Time.deltaTime;
        if (!(currentTimer >= timeBetweenIntensity)) return;
        LighttoFlicker.intensity = Random.Range(minIntensity, maxIntensity);
        currentTimer = 0;
    }

    private void ValidateIntensityBounds() {
        if (!(minIntensity > maxIntensity)) {
            return;
        }

        Debug.LogWarning("Min Intensity is greater than max intensity, swapping values.");
        (minIntensity, maxIntensity) = (maxIntensity, minIntensity);
    }
    
}
