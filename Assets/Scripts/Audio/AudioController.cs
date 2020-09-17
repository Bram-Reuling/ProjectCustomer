using ProjectCustomer.Core;
using UnityEngine;

namespace ProjectCustomer.Audio
{
    public class AudioController : MonoBehaviour
    {
        public AudioSource musicVolume;
        public AudioSource voiceVolume;
        public AudioSource sfxVolume;

        private void Update()
        {
            if (musicVolume != null)
            {
                musicVolume.volume = DataHandler.musicVolume;
            }
            
            if (voiceVolume != null)
            {
                voiceVolume.volume = DataHandler.voiceVolume;
            }
            
            if (sfxVolume != null)
            {
                sfxVolume.volume = DataHandler.sfxVolume;
            }
        }
    }
    
}