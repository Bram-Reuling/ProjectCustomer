using System;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectCustomer.Core
{
    public class AmmoBar : MonoBehaviour
    {
        public Slider slider;

        private void Start()
        {
            slider.maxValue = 100f;
            slider.value = DataHandler.waterAmountLeft;
        }

        private void Update()
        {
            slider.value = DataHandler.waterAmountLeft;
        }
    }
}