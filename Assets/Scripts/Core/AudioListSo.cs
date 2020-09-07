using System.Collections.Generic;
using UnityEngine;

namespace ProjectCustomer.Core
{
    [CreateAssetMenu(fileName = "NewAudioList", menuName = "Audio Manager/Audio List", order = 0)]
    public class AudioListSo : ScriptableObject
    {
        [System.Serializable]
        public class Sound
        {
            public string name;
            public AudioClip clip;
            [Range(0f, 1f)] public float volume;
            [Range(0f, 3f)] public float pitch;

            [HideInInspector] public AudioSource source;
        }
        
        public List<Sound> sounds = new List<Sound>();
    }
}