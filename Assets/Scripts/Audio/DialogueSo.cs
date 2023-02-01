using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Sound/New Dialogue")]
    public class DialogueSo : ScriptableObject
    {
        public SfxSO dialogueSound;
        public string dialogueText;
    }
}