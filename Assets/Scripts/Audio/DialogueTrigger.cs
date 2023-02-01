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
                SoundManager.Instance.PlaySfx(dialogue.dialogueSound);
                DialogueCanvas.Instance.SetText(dialogue);
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