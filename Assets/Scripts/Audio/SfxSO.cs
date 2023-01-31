using System;
using GD.MinMaxSlider;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Audio
{
    [CreateAssetMenu(fileName = "NewSfx", menuName = "Sound/New Sfx")]
    public class SfxSO : ScriptableObject
    {
        public AudioClip[] clips;
        [MinMaxSlider(0f, 1f)]
        public Vector2 volume = new Vector2(.5f, .5f);
        [MinMaxSlider(0f, 1f)]
        public Vector2 pitch = new Vector2(1, 1);
        [SerializeField] private int playIndex;
        [SerializeField] private ClipPlayOrder playOrder;

        #region PreviewSoundCode
        
        #if UNITY_EDITOR

        private AudioSource _previewer;

        private void OnEnable()
        {
            _previewer = EditorUtility
                .CreateGameObjectWithHideFlags("AudioPreview", HideFlags.HideAndDontSave, typeof(AudioSource))
                .GetComponent<AudioSource>();
        }

        private void OnDisable()
        {
            DestroyImmediate(_previewer.gameObject);
        }

        private void PlayPreview()
        {
            Play(_previewer);
        }

        private void StopPreview()
        {
            _previewer.Stop();
        }

        #endif
        
        #endregion

        private AudioClip GetAudioClip()
        {

            var clip = clips[playIndex >= clips.Length ? 0 : playIndex];
            
            switch (playOrder)
            {
                case ClipPlayOrder.Random:
                    playIndex = Random.Range(0, clips.Length);
                    break;
                
                case ClipPlayOrder.InOrder:
                    playIndex = (playIndex + 1) % clips.Length;
                    break;
                
                case ClipPlayOrder.Reverse:
                    playIndex = (playIndex + clips.Length - 1) % clips.Length;
                    break;
            }
            
            return clip;
        }
        
        public AudioSource Play(AudioSource audioSource = null)
        {
            if (clips.Length == 0)
            {
                Debug.Log("No clips added!");
                return null;
            }

            var source = audioSource;
            if (source == null)
            {
                var sourceObj = new GameObject("Sound", typeof(AudioSource));
                source = sourceObj.GetComponent<AudioSource>();
            }

            source.clip = clips[0];
            source.volume = Random.Range(volume.x, volume.y);
            source.pitch = Random.Range(pitch.x, pitch.y);
            
            source.Play();
            
            #if UNITY_EDITOR

            if (source != _previewer)
            {
                Destroy(source.gameObject, source.clip.length/source.pitch);
            }
            
            #else
            
            Destroy(source.gameObject, source.clip.length/source.pitch);
            
            #endif

            return source;
        }

        enum ClipPlayOrder
        {
            Random,
            InOrder,
            Reverse
        }
        
    }
}
