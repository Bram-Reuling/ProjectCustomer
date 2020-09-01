namespace ProjectCustomer.Core.Binocular_States
{
    public abstract class BinocularBaseState
    {
        public abstract void EnterState(BinocularMain binocular);

        public abstract void Update(BinocularMain binocular);

        public abstract void OnCollision(BinocularMain binocular);
    }
}
