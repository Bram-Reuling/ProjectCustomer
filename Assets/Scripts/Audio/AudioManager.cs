using System;
using UnityEngine;

namespace ProjectCustomer.Audio
{
    public class AudioManager : MonoBehaviour
    {
        // if there is nothing playing, pick random song from list and play it.
        public AudioListSo audioList;
        
        private System.Random rnd;
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            rnd = new System.Random();
        }

        private void Update()
        {
            if (!audioSource.isPlaying)
            {
               var index = rnd.Next(audioList.sounds.Count);
               audioSource.clip = audioList.sounds[index].clip;
               audioSource.volume = audioList.sounds[index].volume;
               audioSource.pitch = audioList.sounds[index].pitch;
               
               audioSource.Play();
            }
        }
    }
}
