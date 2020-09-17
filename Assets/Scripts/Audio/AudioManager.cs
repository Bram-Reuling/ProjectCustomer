using System;
using System.Collections;
using ProjectCustomer.Core;
using UnityEngine;

namespace ProjectCustomer.Audio
{
    public class AudioManager : MonoBehaviour
    {
        // if there is nothing playing, pick random song from list and play it.
        public AudioListSo audioListBG;
        public AudioListSo closeToFire;
        public AudioListSo startConversation;
        
        private System.Random rnd;
        public AudioSource audioSource;
        public AudioSource talkSource;

        private bool isConversationOver;
        public AudioClip foxRevive;

        private void Awake()
        {
            if (startConversation != null)
            {
                foreach (var dialogueAudio in startConversation.sounds)
                {
                    dialogueAudio.source = gameObject.AddComponent<AudioSource>();
                    dialogueAudio.source.clip = dialogueAudio.clip;

                    //dialogueAudio.source.volume = dialogueAudio.volume;
                    //dialogueAudio.source.pitch = dialogueAudio.pitch;
                }
            }

            if (closeToFire != null)
            {
                foreach (var diaAudio in closeToFire.sounds)
                {
                    diaAudio.source = gameObject.AddComponent<AudioSource>();
                    diaAudio.source.clip = diaAudio.clip;
                }
            }
            
            audioSource = GetComponent<AudioSource>();
            isConversationOver = false;
        }

        private void Start()
        {
            rnd = new System.Random();
            StartCoroutine(StartDialogue());
            EventBroker.EventOnCloseToFire += CloseToFire;
            EventBroker.EventOnFoxRevive += FoxRevived;
        }

        private void Update()
        {
            audioSource.volume = DataHandler.musicVolume;
            
            if (!audioSource.isPlaying && isConversationOver)
            {
               var index = rnd.Next(audioListBG.sounds.Count);
               audioSource.clip = audioListBG.sounds[index].clip;
               //audioSource.volume = audioListBG.sounds[index].volume;
               //audioSource.pitch = audioListBG.sounds[index].pitch;
               
               audioSource.Play();
            }
        }

        private void FoxRevived()
        {
            if (isConversationOver)
            {
                talkSource.clip = foxRevive;
                talkSource.volume = DataHandler.voiceVolume;
                talkSource.Play();
            }
        }
        
        private void CloseToFire()
        {
            if (isConversationOver)
            {
                var index = rnd.Next(closeToFire.sounds.Count);
                talkSource.clip = closeToFire.sounds[index].clip;
                talkSource.volume = DataHandler.voiceVolume;
                talkSource.Play();
            }
        }
        
        IEnumerator StartDialogue()
        {
            foreach (var dialogueLine in startConversation.sounds)
            {
                var dialogueSource = dialogueLine.source;
                dialogueSource.volume = DataHandler.voiceVolume;
                dialogueSource.Play();
                
                yield return new WaitUntil(() => dialogueSource.isPlaying == false);
            }

            isConversationOver = true;
        }
    }
}
