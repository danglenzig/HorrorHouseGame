using Cinemachine;
using GameConstants;
using UnityEngine;

public class CameraTriggerScript : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera triggerCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.PlayerTag))
        {
            CameraManagerScript.CurrentActiveCamera = triggerCamera;
        }
    }
}