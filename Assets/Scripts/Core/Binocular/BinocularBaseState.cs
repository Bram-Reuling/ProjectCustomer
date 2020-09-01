namespace ProjectCustomer.Core.Binocular
{
    public abstract class BinocularBaseState
    {
        public abstract void EnterState(Binocular binocular);

        public abstract void Update(Binocular binocular);

        public abstract void OnCollision(Binocular binocular);
    }
}
