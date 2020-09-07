using ProjectCustomer.Core;
using UnityEngine;

namespace ProjectCustomer.Audio
{
    public class AgentAudioExtinguishFire : MonoBehaviour
    {
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
            EventBroker.EventOnFireExtinguished += EventOnFireExtinguished;
        }

        private void EventOnFireExtinguished()
        {
            
        }
    }
}
