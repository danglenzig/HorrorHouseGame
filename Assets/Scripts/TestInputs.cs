using UnityEngine;
using UnityEngine.Events;

public class TestInputs : MonoBehaviour
{
    [SerializeField] private UnityEvent inputDown;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaiseEvent();
        }
    }

    private void RaiseEvent()
    {
        inputDown.Invoke();
    }
}