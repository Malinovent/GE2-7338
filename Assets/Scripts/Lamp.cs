using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private MeshRenderer lightMesh;
    
    private void OnEnable()
    {
        Sun.OnDayTimeChanged += ToggleLight;
    }

    private void OnDisable()
    {
        Sun.OnDayTimeChanged -= ToggleLight;
    }

    private void Start()
    {
        TurnOff();
    }

    private void ToggleLight(bool isDayTime)
    {
        if (isDayTime)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }
    
    
    public void TurnOn()
    {
        light.enabled = true;
        lightMesh.sharedMaterial.EnableKeyword("_EMISSION");
    }
    
    public void TurnOff()
    {
        light.enabled = false;
        lightMesh.sharedMaterial.DisableKeyword("_EMISSION");
    }
}
