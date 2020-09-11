using ProjectCustomer.Core;
using UnityEngine;

namespace ProjectCustomer.FireMech
{
    public class TestScript : MonoBehaviour
    {

        public GradientFog gradientScript;
        public FireManager fireManagerScript;

        public GradientColorKey[] colorKey;
        public GradientAlphaKey[] alphaKey;

        public Gradient mygradient;
        public int firenumber = 0;
        public float alphagradient;

     // Start is called before the first frame update
     void Start()
        {

            mygradient = gradientScript.gradient;
        }

        // Update is called once per frame
        void Update()
        {
            firenumber = fireManagerScript.activeFires.Count;


            alphagradient = gradientScript.gradient.alphaKeys[0].alpha*255;

            //if (firenumber >= 1)
            //{
            //    mygradient.alphaKeys = new GradientAlphaKey[0];
            //    mygradient.alphaKeys[0].alpha = 1f;
            //    mygradient.SetKeys(mygradient.colorKeys, mygradient.alphaKeys);
                
            //}

        }
    }
}

