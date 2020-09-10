using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCustomer.FireMech
{
    public class TestScript : MonoBehaviour
    {

        public GradientFog GradientScript;
        public FireManager FireManagerScript;

        public GradientColorKey[] colorKey;
        public GradientAlphaKey[] alphaKey;

        public Gradient mygradient;
        public int firenumber = 0;
        public float alphagradient;

     // Start is called before the first frame update
     void Start()
        {

            mygradient = GradientScript.gradient;
        }

        // Update is called once per frame
        void Update()
        {
            firenumber = FireManagerScript.activeFires.Count;


            alphagradient = GradientScript.gradient.alphaKeys[0].alpha*255;

            //if (firenumber >= 1)
            //{
            //    mygradient.alphaKeys = new GradientAlphaKey[0];
            //    mygradient.alphaKeys[0].alpha = 1f;
            //    mygradient.SetKeys(mygradient.colorKeys, mygradient.alphaKeys);
                
            //}

        }
    }
}

