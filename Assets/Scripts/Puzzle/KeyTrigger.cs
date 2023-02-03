using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Puzzle
{
    public class KeyTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject disableObject;
        [SerializeField] private GameObject key;
        [SerializeField] private Interactable interactable;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == key)
            {
                Open();
            }
        }

        private void Open()
        {
            interactable.ownerTransform.GetComponent<HumanInteraction>().StopInteract();
            Destroy(key);
            disableObject.SetActive(false);
            GameObject.Find("PuzzleManager").GetComponent<CabinetPuzzle>().UpdateState(5);
        }
    }
}
