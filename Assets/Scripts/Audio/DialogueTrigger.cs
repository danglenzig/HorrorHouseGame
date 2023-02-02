using UnityEngine;

namespace Audio
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private DialogueSo dialogue;

        public TriggerType triggerType;
        
        private bool _hasPlayed = false;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!_hasPlayed)
            {
                DialogueCanvas.Instance.QueueDialogue(dialogue);
            }
            
            if (triggerType == TriggerType.PlayOnce)
            {
                _hasPlayed = true;
            }
        }
    }

    public enum TriggerType
    {
        PlayOnce,
        Replay
    }
    
}