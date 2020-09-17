using System;
using ProjectCustomer.Core;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace ProjectCustomer.Other
{
    public class PostBinoculars : MonoBehaviour
    {
        [SerializeField] private PostProcessVolume m_PostProcessVolume = null;

        private void Start()
        {
            EventBroker.EventOnBinocularEquip += EffectsOn;
            EventBroker.EventOnBinocularUnEquip += EffectsOff;
        }

        private void EffectsOn()
        {
            Effects(true);
        }

        private void EffectsOff()
        {
            Effects(false);
        }
        
        private void Effects(bool effectsOn)
        {
            if (m_PostProcessVolume == null) return;

            if (!m_PostProcessVolume.profile.TryGetSettings(out ChromaticAberration chromaticAberration)) return;
            if (!m_PostProcessVolume.profile.TryGetSettings(out LensDistortion lensDistortion)) return;
            
            chromaticAberration.enabled.value = effectsOn;
            lensDistortion.enabled.value = effectsOn;
        }

        private void OnDestroy()
        {
            EventBroker.EventOnBinocularEquip -= EffectsOn;
            EventBroker.EventOnBinocularUnEquip -= EffectsOff;
        }
    }
}
