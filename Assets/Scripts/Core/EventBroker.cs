using System;

namespace ProjectCustomer.Core
{
    public static class EventBroker
    {
        public static Action EventOnBinocularPickUp;
        public static Action EventOnBinocularEquip;
        public static Action EventOnBinocularUnEquip;

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
    }
}
