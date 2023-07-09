namespace AliAwdiAnotherOne.Models
{
    public class FarmerMarket
    {
        public int Id { get; private set; }
        private static int counter=1;
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public FarmerMarket( string name, int quantity)
        {
            Id = counter++;
            Name = name;
            Quantity = quantity < 0 ? throw new Exception("the quantity can't be less than zero") : quantity;

        }
        public void UpdateFramework(  string newname, int newquantity)
        {  Name = newname;
           Quantity = newquantity <=0 ? throw new Exception ("how dare u put quantity below than zero") : newquantity;
        }
        

    }
}

