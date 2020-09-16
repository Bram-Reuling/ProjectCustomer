using System;
using System.Collections;
using UnityEngine;

namespace ProjectCustomer.Audio
{
    public class AudioManager : MonoBehaviour
    {
        // if there is nothing playing, pick random song from list and play it.
        public AudioListSo audioListBG;
        public AudioListSo startConversation;
        
        private System.Random rnd;
        public AudioSource audioSource;

        private bool isConversationOver;

        private void Awake()
        {
            if (startConversation != null)
            {
                foreach (var dialogueAudio in startConversation.sounds)
                {
                    dialogueAudio.source = gameObject.AddComponent<AudioSource>();
                    dialogueAudio.source.clip = dialogueAudio.clip;

                    dialogueAudio.source.volume = dialogueAudio.volume;
                    dialogueAudio.source.pitch = dialogueAudio.pitch;
                }
            }
            audioSource = GetComponent<AudioSource>();
            isConversationOver = false;
        }

        private void Start()
        {
            rnd = new System.Random();
            StartCoroutine(StartDialogue());
        }

        private void Update()
        {
            if (!audioSource.isPlaying && isConversationOver)
            {
               var index = rnd.Next(audioListBG.sounds.Count);
               audioSource.clip = audioListBG.sounds[index].clip;
               audioSource.volume = audioListBG.sounds[index].volume;
               audioSource.pitch = audioListBG.sounds[index].pitch;
               
               audioSource.Play();
            }
        }

        IEnumerator StartDialogue()
        {
            foreach (var dialogueLine in startConversation.sounds)
            {
                var dialogueSource = dialogueLine.source;
                dialogueSource.Play();
                
                yield return new WaitUntil(() => dialogueSource.isPlaying == false);
            }

            isConversationOver = true;
        }
    }
}
