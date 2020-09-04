using System;
using UnityEngine;

namespace ProjectCustomer.Core
{
    public static class EventBroker
    {
        #region Binocular Actions

        public static Action EventOnBinocularPickUp;
        public static Action EventOnBinocularEquip;
        public static Action EventOnBinocularUnEquip;

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

        public static Action EventOnFireStarted;
        public static Action EventOnFireExtinguished;

        public static Action EventOnWaterRefill;

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
    }
}
