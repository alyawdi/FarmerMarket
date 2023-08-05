namespace AliAwdiAnotherOne.Domain.Entities
{
    public class FarmerMarket
    {
        public int Id { get; private set; }
        private static int counter = 1;
        public string Name { get; private set; }
        public int Quantity { get; private set; }

        private FarmerMarket() { }
        public FarmerMarket(string name, int quantity)
        {
            Id = counter++;
            Name = name;
            Quantity = quantity < 0 ? throw new Exception("the quantity can't be less than zero") : quantity;

        }
        public void UpdateFarmerMarket(string newName, int newQuantity)
        {
            Name = newName;
            Quantity = newQuantity <= 0 ? throw new Exception("how dare u put quantity below than zero") : newQuantity;
        }

        public int OrderItem(int orderedQuantity)
        {
            if (Quantity <= 0)
                throw new Exception("This item is not currently available.");

            var newOrderedQuantity = orderedQuantity > Quantity ? Quantity : orderedQuantity;
            Quantity = orderedQuantity > Quantity ? 0 : Quantity - orderedQuantity;
            return newOrderedQuantity;
        }
    }
}





