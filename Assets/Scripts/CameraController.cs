using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera normalCamera;
    [SerializeField] private CinemachineVirtualCamera aimingCamera;

    private void Update()
    {
        bool isAiming = InputManager.isAimingInput;

        if(isAiming)
        {
            ActivateAimingCamera();
        }
        else
        {
            ActivateNormalCamera();
        }
    }

    public void ActivateNormalCamera()
    {
        //normalCamera.transform.gameObject.SetActive(true);
        //aimingCamera.transform.gameObject.SetActive(false);

        normalCamera.Priority = 1;
        aimingCamera.Priority = 0;
    }

    public void ActivateAimingCamera()
    {
        normalCamera.Priority = 0;
        aimingCamera.Priority = 1;
    }
}
