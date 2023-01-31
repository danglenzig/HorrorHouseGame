using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManagerScript : MonoBehaviour
{
    public static CinemachineVirtualCamera CurrentActiveCamera;
    [SerializeField] private CinemachineVirtualCamera startCamera;
    [SerializeField] private List<CinemachineVirtualCamera> cameras = new();

    private void Start()
    {
        CurrentActiveCamera = startCamera;
    }

    private void LateUpdate()
    {
        SwitchToCamera();
    }

    private void SwitchToCamera()
    {
        if (CurrentActiveCamera.Priority == 10)
        {
            return;
        }

        foreach (var virtualCamera in cameras)
        {
            virtualCamera.Priority = 0;
        }

        CurrentActiveCamera.Priority = 10;
    }
}