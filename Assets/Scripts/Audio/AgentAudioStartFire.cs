using System.Collections;
using System.Collections.Generic;
using ProjectCustomer.Core;
using UnityEngine;

namespace ProjectCustomer.Audio
{
    public class AgentAudioStartFire : MonoBehaviour
    {
        private System.Random rnd;
        
        [SerializeField] private AudioListSo calls;
        [SerializeField] private AudioListSo responses;
        
        private void Awake()
        {
            if (calls != null)
            {
                foreach (var callAudio in calls.sounds)
                {
                    callAudio.source = gameObject.AddComponent<AudioSource>();
                    callAudio.source.clip = callAudio.clip;

                    callAudio.source.volume = callAudio.volume;
                    callAudio.source.pitch = callAudio.pitch;
                }   
            }

            if (responses != null)
            {
                foreach (var responseAudio in responses.sounds)
                {
                    responseAudio.source = gameObject.AddComponent<AudioSource>();
                    responseAudio.source.clip = responseAudio.clip;

                    responseAudio.source.volume = responseAudio.volume;
                    responseAudio.source.pitch = responseAudio.pitch;
                }
            }
        }

        private void Start()
        {
            EventBroker.EventOnFireStarted += EventOnFireStarted;
            rnd = new System.Random();
        }

        private void EventOnFireStarted()
        {
            StartCoroutine(Radio());
        }

        IEnumerator Radio()
        {
            // Pick random call
            var callIndex = rnd.Next(0, calls.sounds.Count);

            var callSource = calls.sounds[callIndex].source;
            callSource.Play();

            yield return new WaitUntil(() => callSource.isPlaying == false);
            // if call ends pick random response
            
            Debug.Log("Stopped Playing");

            var responsesIndex = rnd.Next(0, responses.sounds.Count);

            var responseSource = responses.sounds[responsesIndex].source;
            responseSource.Play();

        }
    }
}
