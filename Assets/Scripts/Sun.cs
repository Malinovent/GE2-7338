using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sun : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis = Vector3.left;
    [SerializeField] private float timeForCycleInSeconds = 60.0f;

    private float halfDayInSeconds;
    private float currentTimeOfDay = 0;
    private float degreesOfRotationPerSecond;
    
    private bool isDayTime = true;

    public static event Action<bool> OnDayTimeChanged;

    void Start()
    {
        halfDayInSeconds = timeForCycleInSeconds / 2;
        degreesOfRotationPerSecond = 360 / timeForCycleInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxis, degreesOfRotationPerSecond * Time.deltaTime);
        
        currentTimeOfDay += Time.deltaTime;

        if (currentTimeOfDay > halfDayInSeconds)
        {
            isDayTime = !isDayTime;
            currentTimeOfDay = 0;
            
            OnDayTimeChanged?.Invoke(isDayTime);
        }
        
    }
}
