using System;

namespace ProjectCustomer.Core
{
    public static class EventBroker
    {
        public static Action EventOnBinocular;

        public static void CallEventOnBinocular()
        {
            EventOnBinocular?.Invoke();
        }
    }
}
