using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class GhostInteraction : MonoBehaviour, IPickupInteraction
{
    private Interactable interactedObject;
    private List<Interactable> possibleInteractables;

    public void AddInteractable(Interactable interactable)
    {
        possibleInteractables.Add(interactable);
    }

    public void RemoveInteractable(Interactable interactable)
    {
        possibleInteractables.Remove(interactable);
    }

    public void StopInteract()
    {
        interactedObject = null;
    }
}

public interface IPickupInteraction
{
    void AddInteractable(Interactable interactable);
    void StopInteract();
}

public interface ISimpleInteraction
{
    void Interact();
}