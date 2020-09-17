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
        public static bool convoIsOver = false;

        public static float musicVolume=1;
        public static float voiceVolume=1;
        public static float sfxVolume=1;
        public static float sensetivity=1000;
    }
}
