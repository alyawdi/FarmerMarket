namespace AliAwdiAnotherOne.Domain.Entities
{
    public class RestaurantOrder
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int RequiredQuantity { get; private set; }
        public int FinalCost { get; private set; }

        private RestaurantOrder() { }
        public RestaurantOrder(string name, int requiredQuantity, int finalCost)
        {
            Name = name;
            RequiredQuantity = requiredQuantity <= 0 ? throw new Exception("Quantity must be positive.") : requiredQuantity;
            FinalCost = finalCost;
        }
        public void UpdateRestaurantOrder(string newname, int newQuantity)
        {
            Name = newname;
            RequiredQuantity = newQuantity <= 0 ? throw new Exception("Quantity must be positive.") : newQuantity;
        }
    }
}
