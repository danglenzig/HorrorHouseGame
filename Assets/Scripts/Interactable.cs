using GameConstants;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    [SerializeField] private Collider interactableTrigger;

    [Header("Offset From Owner Transform When Held/Picked Up")] [SerializeField]
    private Vector3 followOffset;

    [SerializeField] private Transform parentTransform;
    [SerializeField] private Collider physicsCollider;

    private InteractableState interactableState;
    private bool isEnabled;
    private Transform ownerTransform;

    private void Start()
    {
        MakeTrigger();
    }

    private void Update()
    {
        if (ownerTransform != null && interactableState == InteractableState.Interacted)
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

        if (!other.CompareTag(Tags.PlayerTag) || !other.TryGetComponent<HumanInteraction>(out var humanInteraction))
        {
            return;
        }

        // TODO: Show input that interaction possible
        humanInteraction.AddPossibleInteractable(this);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isEnabled || interactableState == InteractableState.Used)
        {
            return;
        }

        if (!other.CompareTag(Tags.PlayerTag) || !other.TryGetComponent<HumanInteraction>(out var humanInteraction))
        {
            return;
        }

        humanInteraction.RemovePossibleInteractable(this);
    }

    public void PickUp(Transform newOwner)
    {
        ownerTransform = newOwner;
        ToggleCollider();
        interactableState = InteractableState.Interacted;
    }

    public void Drop()
    {
        ownerTransform = null;
        ToggleCollider();
        interactableState = InteractableState.Free;
    }

    private void FollowOwner()
    {
        parentTransform.position = ownerTransform.position + followOffset;
    }

    private void MakeTrigger()
    {
        isEnabled = true;
        interactableTrigger.isTrigger = true;
    }

    private void ToggleCollider()
    {
        isEnabled = !isEnabled;
        interactableTrigger.enabled = !interactableTrigger.enabled;
        physicsCollider.enabled = !physicsCollider.enabled;
    }
}

internal enum InteractableState
{
    Free,
    Interacted,
    Used
}