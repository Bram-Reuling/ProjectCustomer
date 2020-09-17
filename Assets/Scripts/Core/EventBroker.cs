using System;
using UnityEngine;

namespace ProjectCustomer.Core
{
    public static class EventBroker
    {
        #region Binocular Actions

        public static event Action EventOnBinocularPickUp;
        public static event Action EventOnBinocularEquip;
        public static event Action EventOnBinocularUnEquip;

        #endregion

        #region Binocular Methods

        public static void CallEventOnBinocularPickUp()
        {
            EventOnBinocularPickUp?.Invoke();
        }
        
        public static void CallEventOnBinocularEquip()
        {
            EventOnBinocularEquip?.Invoke();
        }

        public static void CallEventOnBinocularUnEquip()
        {
            EventOnBinocularUnEquip?.Invoke();
        }

        #endregion

        #region Fire Extinguisher Actions

        public static event Action EventOnFireStarted;
        public static event Action EventOnFireExtinguished;

        public static event Action EventOnWaterRefill;

        #endregion

        #region Fire Extinguisher Methods

        public static void CallEventOnFireStarted()
        {
            EventOnFireStarted?.Invoke();
        }

        public static void CallEventOnFireExtinguished()
        {
            EventOnFireExtinguished?.Invoke();
        }

        public static void CallEventOnWaterRefill()
        {
            EventOnWaterRefill?.Invoke();
        }

        #endregion

        #region Other Actions

        public static event Action EventOnTimerRunOut;
        public static event Action EventOnMaxFires;
        public static event Action EventOnFoxRevive;
        public static event Action EventOnFoxDown;
        public static event Action EventOnCloseToFire;

        #endregion

        #region Other Methods

        public static void CallEventOnTimerRunOut()
        {
            EventOnTimerRunOut?.Invoke();
        }

        public static void CallEventOnMaxFires()
        {
            EventOnMaxFires?.Invoke();
        }

        public static void CallEventOnFoxRevive()
        {
            EventOnFoxRevive?.Invoke();
        }

        public static void CallEventOnFoxDown()
        {
            EventOnFoxDown?.Invoke();
        }
        
        public static void CallEventOnCloseToFire()
        {
            EventOnCloseToFire?.Invoke();
        }
        
        #endregion
    }
}
