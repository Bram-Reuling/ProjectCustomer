using UnityEngine;
using UnityEngine.UI;

namespace ProjectCustomer.Core
{
    public class SettingsControl : MonoBehaviour
    {
        public Slider musicVolume;
        public Slider voiceVolume;
        public Slider sfxVolume;
        public Slider sensitivity;
    
        // Start is called before the first frame update
        void Start()
        {
            musicVolume.maxValue = 1;
            voiceVolume.maxValue = 1;
            sfxVolume.maxValue = 1;
            sensitivity.maxValue = 1000;

            musicVolume.value = musicVolume.maxValue;
            voiceVolume.value = voiceVolume.maxValue;
            sfxVolume.value = sfxVolume.maxValue;
            sensitivity.value = sensitivity.maxValue;
        }

        public void OnMusicVolumeChange()
        {
            DataHandler.musicVolume = musicVolume.value;
        }
        
        public void OnVoiceVolumeChange()
        {
            DataHandler.voiceVolume = voiceVolume.value;
        }
        
        public void OnSFXVolumeChange()
        {
            DataHandler.sfxVolume = sfxVolume.value;
        }
        
        public void OnSensitivityChange()
        {
            DataHandler.sensetivity = sensitivity.value;
        }
    }
}
