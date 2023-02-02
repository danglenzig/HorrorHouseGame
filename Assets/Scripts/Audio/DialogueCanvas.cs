using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Audio
{
    public class DialogueCanvas : MonoBehaviour
    {
        public static DialogueCanvas Instance { get; private set; }

        private TextMeshProUGUI _dialogueTxt;

        [SerializeField] private bool isPlaying;
        private Queue<DialogueSo> _dialogueQueue = new Queue<DialogueSo>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }

            _dialogueTxt = GetComponentInChildren<TextMeshProUGUI>();
            _dialogueTxt.enabled = false;
            isPlaying = false;
        }

        public void QueueDialogue(DialogueSo dialogue)
        {
            _dialogueQueue.Enqueue(dialogue);

            if (!isPlaying)
            {
                isPlaying = true;
                StartCoroutine(PlayDialogue());
            }
        }

        private IEnumerator PlayDialogue()
        {
            //Get dialogue and wait for sound to start (roughly .5 seconds)
            DialogueSo dialogueToPlay = _dialogueQueue.Dequeue();
            SoundManager.Instance.PlaySfx(dialogueToPlay.dialogueSound);
            yield return new WaitForSeconds(.5f);
            
            //Set text and enable it
            _dialogueTxt.text = dialogueToPlay.dialogueText;
            _dialogueTxt.enabled = true;
            
            //Wait for dialogue to finish and disable the text
            yield return new WaitForSeconds(dialogueToPlay.dialogueSound.clips[0].length);
            _dialogueTxt.enabled = false;
            
            //If there are more queued... play next!
            if (_dialogueQueue.Count > 0)
            {
                StartCoroutine(PlayDialogue());
            }
            else
            {
                isPlaying = false;
            }
        }
    }
}