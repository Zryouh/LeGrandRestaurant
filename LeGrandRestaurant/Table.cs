namespace LeGrandRestaurant
{
    public class Table
    {
        public void AffecterA(Client client)
        {
            EstLibre = false;
        }

        public void Libérer()
        {
            EstLibre = true;
        }

        internal bool EstLibre { get; private set; } = true;
    }
}
