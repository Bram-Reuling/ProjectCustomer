using System.Collections.Generic;
using UnityEngine;

namespace ProjectCustomer.Core
{
    public abstract class DataHandler
    {
        public static int waterParticles;
        public static float waterAmountLeft;
        public static List<GameObject> openFires;

        public static int numberOfFiresLeft = 0;
        public static int numberOfFiresPutOut = 0;
        public static int numberOfFoxesRevived = 0;
        public static int numberOfFoxesInScene = 0;

        public static bool playerLost = false;

        public static float musicVolume;
        public static float voiceVolume;
        public static float sfxVolume;
        public static float sensetivity;
    }
}
