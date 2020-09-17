using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCustomer.Other
{
    public class OptionsButtonScript : MonoBehaviour
    {

        public GameObject OptionsCanvas;
        public GameObject MainCanvas;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OptionsButtonClick()
        {
            MainCanvas.SetActive(false);
            OptionsCanvas.SetActive(true);
        }

        public void BackToMainClick()
        {
            MainCanvas.SetActive(true);
            OptionsCanvas.SetActive(false);
        }

    }

}