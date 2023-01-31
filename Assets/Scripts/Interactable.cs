using System;
using GameConstants;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    [SerializeField] private Collider interactableTrigger;
    private InteractableState interactableState;
    private bool isEnabled;
    private Transform ownerTransform;

    private void Start()
    {
        MakeTrigger();
    }

    private void Update()
    {
        if (ownerTransform != null && interactableState != InteractableState.Used)
        {
            FollowOwner();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isEnabled)
        {
            return;
        }

        if (!other.CompareTag(Tags.PlayerTag) || !other.TryGetComponent<GhostInteraction>(out var interactable))
        {
            return;
        }

        // TODO: Show input that interaction possible
        interactable.AddInteractable(this);
        ownerTransform = interactable.transform;
        interactableState = InteractableState.Interacted;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isEnabled)
        {
            return;
        }

        if (other.CompareTag(Tags.PlayerTag))
        {
            
        }
    }

    private void FollowOwner()
    {
        transform.position = ownerTransform.position;
    }

    private void MakeTrigger()
    {
        interactableTrigger.isTrigger = true;
    }

    public void ToggleCollider()
    {
        isEnabled = !isEnabled;
    }
}

internal enum InteractableState
{
    Free,
    Interacted,
    Used
}